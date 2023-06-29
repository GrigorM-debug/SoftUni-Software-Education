using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    internal class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string url)
        {
            if(!ValidUrl(url))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {url}!";
        }

        public string Call(string phoneNumber)
        {
            if(!ValidNumber(phoneNumber))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Calling... {phoneNumber}";
        }

        private bool ValidNumber(string phoneNumber)
        => phoneNumber.All(c => char.IsDigit(c));
        //{
        //    for(int i = 0; i < phoneNumber.Length; i++)
        //    {
        //        return char.IsDigit(phoneNumber[i]);
        //    }
        //    return false;
        //}
        private bool ValidUrl(string url)
         => url.All(url => !char.IsDigit(url)); 
    }
}
