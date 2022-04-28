using App;
using App.Services.Validators;
using App.Services.Validators.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AppTest
{
    public class CustomerCreditCheckerTest
    {
        private ICustomerCreditChecker customerCreditChecker;
        private Mock<CustomerCreditServiceClient> customerCreditServiceClient;

        public CustomerCreditCheckerTest()
        {
            customerCreditChecker = new CustomerCreditChecker();
            customerCreditServiceClient = new Mock<CustomerCreditServiceClient>();
        }


        //[Fact]
        //public void CheckCustomerCredit_IfVeryImporantClient_NoCreditLimit()
        //{
        //    Company company = new Company { Name = "VeryImportantClient" };
        //    Customer customer = new Customer { };

        //    customerCreditServiceClient.Setup(client => client.GetCreditLimit(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()));

        //    customerCreditChecker.CheckCustomerCredit(customer, company);

        //    Assert.False(customer.HasCreditLimit);
        //}

        //[Fact]
        //public void CheckCustomerCredit_IfImportantClient_DoubleCreditLimit()
        //{
        //    Company company = new Company { Name = "ImportantClient" };
        //    Customer customer = new Customer { CreditLimit = 5 };



        //    customerCreditChecker.CheckCustomerCredit(customer, company);

        //    Assert.Equal(10, customer.CreditLimit);
        //}
    }
}
