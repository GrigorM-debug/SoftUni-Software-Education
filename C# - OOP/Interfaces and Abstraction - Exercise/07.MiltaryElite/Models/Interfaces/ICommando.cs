﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiltaryElite.Models.Interfaces
{
    public interface ICommando
    {
        IReadOnlyCollection<IMission> Missions { get; }
    }
}
