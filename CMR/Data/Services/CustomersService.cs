using CMR.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMR.Data.Services
{
    public class CustomersService : ICustomersservice
    {
        private readonly ApplicationDbContext _context;

        public object Customer => throw new NotImplementedException();

        public CustomersService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }
        public Customer GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Customer Update(int Id, Customer newCustomer)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
