using App.Models;
using App.Services.Validators.Interfaces;

namespace App.Services.Validators
{
    public class CustomerCreditChecker : ICustomerCreditChecker
    {
        public CustomerCreditChecker()
        {

        }
        public CreditCheckResult CheckCustomerCredit(Customer customer, Company company)
        {
            CreditCheckResult result = new CreditCheckResult();

            if (company.Name == "VeryImportantClient")
            {
                // Skip credit check
                result.HasCreditLimit = false;
            }
            else if (company.Name == "ImportantClient")
            {
                // Do credit check and double credit limit
                result.HasCreditLimit = true;
                using (var customerCreditService = new CustomerCreditServiceClient())
                {
                    var creditLimit = customerCreditService.GetCreditLimit(customer.Firstname, customer.Surname, customer.DateOfBirth);
                    creditLimit = creditLimit * 2;
                    result.CreditLimit = creditLimit;
                }
            }
            else
            {
                // Do credit check
                result.HasCreditLimit = true;
                using (var customerCreditService = new CustomerCreditServiceClient())
                {
                    var creditLimit = customerCreditService.GetCreditLimit(customer.Firstname, customer.Surname, customer.DateOfBirth);
                    result.CreditLimit = creditLimit;
                }
            }

            if (result.HasCreditLimit && result.CreditLimit < 500)
            {
                result.failed = true;
            }

            return result;
        }
    }
}
