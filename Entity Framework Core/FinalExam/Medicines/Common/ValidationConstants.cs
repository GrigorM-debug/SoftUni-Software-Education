using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Medicines.Common
{
    public static class ValidationConstants
    {
        public const int PharmacyNameMaxLength = 50;
        public const int PharmacyNameMinLength = 2;
        public const int PharmacyPhoneNumberLenght = 14;
        public const string RegexPattern = @"\(\d{3}\) \d{3}-\d{4}";

        public const int MedicineNameMaxLength = 150;
        public const int MedicineNameMinLength = 3;
        public const double MedicinePriceMinRange = 0.01;
        public const double MedicinePriceMaxRange = 1000.00;
        public const int MedicineProducerMaxLength = 100;
        public const int MedicineProducerMinLength = 3;

        public const int PatientFullNameMaxLength = 100;
        public const int PatientFullNameMinLength = 5;
    }
}
