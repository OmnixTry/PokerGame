﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGameProject.Combinations
{
    interface ICombinationChecker
    {
        void SetNext(ICombinationChecker nextHandler);
        void CheckCombination(HandValue handValue);
    }
}