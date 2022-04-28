using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Models
{
    public class CreditCheckResult
    {
        public bool HasCreditLimit { get; set; }
        public int CreditLimit { get; set; }
        public bool failed { get; set; }
    }
}
