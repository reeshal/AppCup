using System;
using System.Collections.Generic;
using System.Text;

namespace NoPoverty.Models
{
    public static class Global
    {
        public static Users logger { get; set; }
        public static Users currentDonor { get; set; }
        public static Users currentRep { get; set; }
    }
}
