using CMR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMR.Data.Services
{
    public interface ICustomersservice
    {
        object Customer { get; }

        Task<IEnumerable<Customer>> GetAll();
        Customer GetById(int Id);
        void Add(Customer customer);
        Customer Update(int Id, Customer newCustomer);
        void Delete(int Id);
    }
}
