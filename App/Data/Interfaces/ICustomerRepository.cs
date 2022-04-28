using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Data.Interfaces
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
    }
}
