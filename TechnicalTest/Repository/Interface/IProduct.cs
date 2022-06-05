using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTest.Models;

namespace TechnicalTest.Repository.Interface
{
   public interface IProduct
    {
        List<Product> GetAll();
        Product GetById(int ProductId);
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);
        void Save();

    }
}
