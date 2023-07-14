using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProvider.Repositories.Abstractions
{
    public interface IClientRepository : IRepository<Client>
    {
        public List<Client> GetAll();
        public Client GetById(int id);
    }
}
