﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DTOs.Import
{
    public class ImportCarDto
    {
        public ImportCarDto()
        {
            this.PartsId = new HashSet<int>();
        }

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public int TraveledDistance { get; set; }
        public virtual ICollection<int> PartsId { get; set; }
    }
}