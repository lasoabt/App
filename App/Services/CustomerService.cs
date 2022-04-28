using App.Data;
using App.Data.Interfaces;
using App.Models;
using App.Services.Interfaces;
using App.Services.Validators.Interfaces;
using System;

namespace App
{
    public class CustomerService : ICustomerService
    {
        private readonly ICompanyRepository _companyRepo;
        private readonly Customer _customer;
        private readonly ICustomerCreditChecker _creditChecker;
        private readonly ICustomerRepository _customerRepo;
        public CustomerService(string firname, string surname, string email, DateTime dateOfBirth, ICompanyRepository companyrepo, ICustomerCreditChecker creditChecker, ICustomerRepository customerRepo)
        {
            if (string.IsNullOrEmpty(firname) || string.IsNullOrEmpty(surname))
            {
                throw new Exception("First Name/Surname can not be null");
            }

            if (!email.Contains("@") && !email.Contains("."))
            {
                throw new Exception("Invalid email address");
            }

            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (age < 21)
            {
                throw new Exception("Age must be above 21");
            }

            _customer = new Customer
            {
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                Firstname = firname,
                Surname = surname
            };

            _companyRepo = companyrepo;
            _creditChecker = creditChecker;
            _customerRepo = customerRepo;
        }

        public bool AddCustomer(int companyId)
        {
            var company = _companyRepo.GetById(companyId);

            CreditCheckResult result = _creditChecker.CheckCustomerCredit(_customer, company);

            if (result.failed)
                return false;

            _customer.CreditLimit = result.CreditLimit;
            _customer.HasCreditLimit = result.HasCreditLimit;
            _customer.Company = company;

            _customerRepo.AddCustomer(_customer);

            return true;
        }
    }
}
