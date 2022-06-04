using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTest.Models;

namespace TechnicalTest.Repository.Interface
{
    public interface ISalesMaster
    {
        List<SalesMaster> GetAll();
        SalesMaster GetById(int Id);
        void Add(SalesMaster salesMasters);
        void Delete(SalesMaster salesMasters);
        void Update(SalesMaster salesMasters);
        void Save();
    }
}
