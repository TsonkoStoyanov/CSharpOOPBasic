﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P10_Explicit_Interfaces
{
    public interface IResident
    {
        string Name { get; set; }

        string Country { get; set; }


        string GetName();
    }
}
