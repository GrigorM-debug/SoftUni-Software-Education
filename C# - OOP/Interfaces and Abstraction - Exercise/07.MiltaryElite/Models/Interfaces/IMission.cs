﻿using MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiltaryElite.Models.Interfaces
{
    public interface IMission
    {
        string CodeName { get; }

        State State { get; }
    }
}
