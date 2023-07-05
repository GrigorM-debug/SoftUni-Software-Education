﻿using MilitaryElite.Enums;
using MiltaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiltaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, State state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName {get; private set;}  

        public State State { get; private set; }

        public void CompleteMission()
        {
            State = State.Finished;
        }

        public override string ToString()
        {
            return $"Code name: {CodeName} State: {State}";
        }
    }
}
