using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCompetition.Utilities.Messages
{
    public static class ExceptionMessages
    {
        public const string NameNullOrWhitespace = "Name cannot be null or whitespace!";

        public const string CategoryNotAllowed = "University category {0} is not allowed in the application!";

        public const string CapacityNegative = "University capacity cannot be a negative value!";
    }
}
