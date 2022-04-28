using App;
using App.Data;
using App.Data.Interfaces;
using App.Models;
using App.Services.Validators.Interfaces;
using Moq;
using System;
using Xunit;

namespace AppTest
{
    public class CustomerServiceTest
    {
        private Mock<ICompanyRepository> companyrepo;
        private Mock<Customer> customer;
        private Mock<ICustomerCreditChecker> creditChecker;
        private Mock<ICustomerRepository> customerRepo;

        public CustomerServiceTest()
        {
            companyrepo = new Mock<ICompanyRepository>();
            customer = new Mock<Customer>();
            creditChecker = new Mock<ICustomerCreditChecker>();
            customerRepo = new Mock<ICustomerRepository>();
        }

        [Fact]
        public void CustomerService_FirstNameIsNull_ThrowsException()
        {
            var exception = Assert.Throws<Exception>(() => new CustomerService(null, "Doe", "email@gmail.com", new DateTime(1987, 09, 11), companyrepo.Object, creditChecker.Object, customerRepo.Object));
           
            Assert.Equal("First Name/Surname can not be null", exception.Message);
        }

        [Fact]
        public void CustomerService_SurNameIsNull_ThrowsException()
        {
            var exception = Assert.Throws<Exception>(() => new CustomerService("John", null, "email@gmail.com", new DateTime(1987, 09, 11), companyrepo.Object, creditChecker.Object, customerRepo.Object));

            Assert.Equal("First Name/Surname can not be null", exception.Message);
        }

        [Fact]
        public void CustomerService_InvalidEmail_ThrowsException()
        {
            var exception = Assert.Throws<Exception>(() => new CustomerService("John", "Doe", "emailgmailcom", new DateTime(1987, 09, 11), companyrepo.Object, creditChecker.Object, customerRepo.Object));

            Assert.Equal("Invalid email address", exception.Message);
        }

        [Fact]
        public void CustomerService_UnderAge_ThrowsException()
        {
            var exception = Assert.Throws<Exception>(() => new CustomerService("John", "Doe", "email@gmail.com", new DateTime(2010, 09, 11), companyrepo.Object, creditChecker.Object, customerRepo.Object));

            Assert.Equal("Age must be above 21", exception.Message);
        }
    }
}
