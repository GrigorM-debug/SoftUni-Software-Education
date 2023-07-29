using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCompetition.Models.Contracts
{
    public interface ISubject
    {
        public int Id { get; }

        public string Name { get; }

        public double Rate { get; }
    }
}
