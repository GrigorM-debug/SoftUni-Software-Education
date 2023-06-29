using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public string Call(string phoneNumber)
        {
            if (!ValidNumber(phoneNumber))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Dialing... {phoneNumber}";
        }

        private bool ValidNumber(string phoneNumber)
          => phoneNumber.All(c => char.IsDigit(c));

        /*{
         for(int i = 0; i < phoneNumber.Length; i++)
        {
            return char.IsDigit(phoneNumber[i]);
        }
        return false;
         {*/
    }
}
