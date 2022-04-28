using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Services.Validators.Interfaces
{
    public interface ICustomerCreditChecker
    {
        CreditCheckResult CheckCustomerCredit(Customer customer, Company company);
    }
}
