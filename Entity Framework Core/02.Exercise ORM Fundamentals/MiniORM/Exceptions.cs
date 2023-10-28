using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniORM
{
    internal class Exceptions
    {
        public const string ItemIsNull = "Entity cannot be null";

        public const string InvalidEntity = "{0} Invalid Entities Found in {1}";
    }
}
