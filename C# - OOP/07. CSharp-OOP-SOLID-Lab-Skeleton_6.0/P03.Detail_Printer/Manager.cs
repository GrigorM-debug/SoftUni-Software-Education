﻿using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string GetInfo()
        {
            StringBuilder sb = new();

            sb.AppendLine(this.Name);
            sb.AppendLine(string.Join(Environment.NewLine, this.Documents));

            return sb.ToString().TrimEnd();
        }
    }
}