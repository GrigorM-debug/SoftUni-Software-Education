using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCompetition.Models.Contracts
{
    public interface IUniversity
    {
        public int Id { get; }

        public string Name { get; }

        public string Category { get; }

        public int Capacity { get; }

        public IReadOnlyCollection<int> RequiredSubjects { get; }
    }
}
