using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTest.Models;

namespace TechnicalTest.Repository.Interface
{
   public interface ISalesDetail
    {
        List<SalesDetail> GetAll();
        SalesDetail GetById(int Id);
        void Add(SalesDetail salesDetail);
        void Delete(SalesDetail salesDetail);
        void Update(SalesDetail salesDetail);
        void Save();
    }
}
