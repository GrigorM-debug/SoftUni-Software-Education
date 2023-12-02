using System.Globalization;
using Invoices.Extensions;
using Medicines.Data.Models.Enums;
using Medicines.DataProcessor.ExportDtos;
using Microsoft.EntityFrameworkCore;

namespace Medicines.DataProcessor
{
    using Medicines.Data;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            var patiens = context.Patients
                .AsNoTracking()
                .Where(patient => patient.PatientsMedicines.Any(medicine => medicine.Medicine.ProductionDate > DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture)))
                .OrderByDescending(x => x.PatientsMedicines.Count)
                .ThenBy(x =>x.FullName)
                .Select(x => new ExportPatientsDto()
                {
                    Gender = x.Gender.ToString().ToLower(),
                    Name = x.FullName,
                    AgeGroup = x.AgeGroup.ToString(),
                    Medicines = x.PatientsMedicines
                        .OrderByDescending(x => x.Medicine.ExpiryDate)
                        .ThenBy(x => x.Medicine.Price)
                        .Select(p=> new ExportMedicninesDto()
                        {
                            Name = p.Medicine.Name,
                            Price = p.Medicine.Price.ToString("f2", CultureInfo.InvariantCulture),
                            Category = p.Medicine.Category.ToString().ToLower(),
                            Producer = p.Medicine.Producer,
                            BestBefore = p.Medicine.ExpiryDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                        })
                        .ToArray()
                })
                .ToArray();

            return XmlSerializationExtension.SerializeToXml<ExportPatientsDto[]>(patiens, "Patients");
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            var medicines = context.Medicines
                .AsNoTracking()
                .Where(m => m.Category == (Category)medicineCategory && m.Pharmacy.IsNonStop)
                .OrderBy(x => x.Price)
                .ThenBy(x => x.Name)
                .Select(m => new ExportMedicinesDto()
                {
                    Name = m.Name,
                    Price = m.Price.ToString("f2"),
                    Pharmacy = new ExportPharmacyDto()
                    {
                        Name = m.Pharmacy.Name,
                        PhoneNumber = m.Pharmacy.PhoneNumber
                    }
                })
                .ToArray();

            return JsonSerializationExtension.SerializeToJson<ExportMedicinesDto[]>(medicines);
        }
    }
}
