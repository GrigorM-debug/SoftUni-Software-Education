using System.Globalization;
using System.Text;
using Invoices.Extensions;
using Medicines.Common;
using Medicines.Data.Models;
using Medicines.Data.Models.Enums;
using Medicines.DataProcessor.ImportDtos;

namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            var patientsDtos = JsonSerializationExtension.DeserializeFromJson<ImportPatientsDto[]>(jsonString);

            var patients = new HashSet<Patient>();
            var result = new StringBuilder();
            foreach (var patientDto in patientsDtos)
            {
                if (!IsValid(patientDto)
                    || !Enum.IsDefined(typeof(AgeGroup), patientDto.AgeGroup)
                    || !Enum.IsDefined(typeof(Gender), patientDto.Gender))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var patient = new Patient()
                {
                    FullName = patientDto.FullName,
                    AgeGroup = (AgeGroup)patientDto.AgeGroup,
                    Gender = (Gender)patientDto.Gender
                };

                foreach (var medicineId in patientDto.Medicines)
                {
                    if (patient.PatientsMedicines.Any(pm => pm.MedicineId == medicineId))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var patientMedicine = new PatientMedicine()
                    {
                        Patient = patient,
                        MedicineId = medicineId
                    };

                    patient.PatientsMedicines.Add(patientMedicine);
                    patients.Add(patient);
                }

                result.AppendLine(string.Format(SuccessfullyImportedPatient, patient.FullName, patient.PatientsMedicines.Count));
            }

            context.Patients.AddRange(patients);
            context.SaveChanges();

            return result.ToString().Trim();
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            var pharmaciesDto = XmlSerializationExtension.DeserializeFromXml<ImportPharmacyDto[]>(xmlString, "Pharmacies");

            var pharmacies = new HashSet<Pharmacy>();
            var result = new StringBuilder();
            foreach (var pharmacyDto in pharmaciesDto)
            {
                if (!IsValid(pharmacyDto)
                    || pharmacyDto.IsNonStop != "true"
                    && pharmacyDto.IsNonStop != "false")
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var pharmacy = new Pharmacy()
                {
                    IsNonStop = bool.Parse(pharmacyDto.IsNonStop),
                    Name = pharmacyDto.Name,
                    PhoneNumber = pharmacyDto.PhoneNumber
                };

                foreach (var medicineDto in pharmacyDto.Medicines)
                {
                    DateTime productionDate;
                    var parseProductionDate = DateTime.TryParseExact(medicineDto.ProductionDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out productionDate);

                    DateTime expiryDate;
                    var parseExpiryDate = DateTime.TryParseExact(medicineDto.ExpiryDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out expiryDate);

                    if (!IsValid(medicineDto)
                        || productionDate >= expiryDate
                        || pharmacy.Medicines.Any(m => m.Name == medicineDto.Name && m.Producer == medicineDto.Producer)
                        || !Enum.IsDefined(typeof(Category), medicineDto.Category))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var medicine = new Medicine()
                    {
                        Category = (Category)medicineDto.Category,
                        Name = medicineDto.Name,
                        Price = decimal.Parse(medicineDto.Price),
                        ProductionDate = productionDate,
                        ExpiryDate = expiryDate,
                        Producer = medicineDto.Producer
                    };

                    pharmacy.Medicines.Add(medicine);
                    pharmacies.Add(pharmacy);
                }

                result.AppendLine(string.Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacy.Medicines.Count));
            }

            context.Pharmacies.AddRange(pharmacies);
            context.SaveChanges();

            return result.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
