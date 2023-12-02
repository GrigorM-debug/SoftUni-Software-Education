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

            var validPationts = new HashSet<Patient>();

            var medicineIds = context.Medicines.Select(x => x.Id).ToArray();

            var sb = new StringBuilder();

            foreach (var patientDto in patientsDtos)
            {
                if (!IsValid(patientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var patient = new Patient()
                {
                    FullName = patientDto.FullName,
                    AgeGroup = (AgeGroup)patientDto.AgeGroup,
                    Gender = (Gender)patientDto.Gender
                };

                foreach (var medicineId in patientDto.Medicines.Distinct())
                {
                    if (!medicineIds.Contains(medicineId))
                    {
                        sb.AppendLine(ErrorMessage); 
                        continue;
                    }

                    var patientMedicine = new PatientMedicine()
                    {
                        Patient = patient,
                        MedicineId = medicineId
                    };

                    if (patient.PatientsMedicines.Contains(patientMedicine))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    patient.PatientsMedicines.Add(patientMedicine);
                }

                sb.AppendLine(string.Format(SuccessfullyImportedPatient, patient.FullName,
                    patient.PatientsMedicines.Count));

                validPationts.Add(patient);
            }

            context.AddRange(validPationts);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            var pharmaciesDto = XmlSerializationExtension.DeserializeFromXml<ImportPharmacyDto[]>(xmlString, "Pharmacies");

            var result = new StringBuilder();

            foreach (var pharmacyDto in pharmaciesDto)
            {
                if (!IsValid(pharmacyDto))
                {
                    result.AppendLine("Invalid Data!");
                    continue;
                }

                var hasInvalidMedicine = pharmacyDto.Medicines
                    .Any(medicineDto => !IsValid(medicineDto) || context.Medicines.Any(m => m.Name == medicineDto.Name && m.Producer == medicineDto.Producer));

                if (hasInvalidMedicine)
                {
                    result.AppendLine("Invalid Data!");
                    continue;
                }

                var pharmacy = new Pharmacy
                {
                    Name = pharmacyDto.Name,
                    PhoneNumber = pharmacyDto.PhoneNumber,
                    IsNonStop = bool.Parse(pharmacyDto.IsNonStop),
                    Medicines = pharmacyDto.Medicines
                        .Select(medicineDto => new Medicine
                        {
                            Name = medicineDto.Name,
                            Price = decimal.Parse(medicineDto.Price),
                            Category = (Category)medicineDto.Category,
                            ProductionDate = DateTime.ParseExact(medicineDto.ProductionDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                            ExpiryDate = DateTime.ParseExact(medicineDto.ExpiryDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                            Producer = medicineDto.Producer
                        })
                        .ToList()
                };

                context.Pharmacies.Add(pharmacy);
                context.SaveChanges();

                result.AppendLine($"Successfully imported pharmacy - {pharmacy.Name} with {pharmacy.Medicines.Count} medicines.");
            }

            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
