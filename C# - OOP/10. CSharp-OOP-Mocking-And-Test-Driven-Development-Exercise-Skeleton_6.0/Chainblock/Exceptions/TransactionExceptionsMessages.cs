using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chainblock.Exceptions
{
    public static class TransactionExceptionsMessages
    {
        public const string IdIsZroOrNegative = "Id should be positive!";

        public const string FromIsNullOrWhiteSpace = "From is null or white space!";

        public const string ToIsNullOrWhiteSpace = "To is null or white space";

        public const string AmountIsZeroOrNegative = "Amount should be positive!";
    }
}
