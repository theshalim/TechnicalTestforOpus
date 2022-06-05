using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTest.Data;
using TechnicalTest.Models;
using TechnicalTest.Repository.Interface;

namespace TechnicalTest.Repository
{
    public class ProductService : IProduct
    {
        private readonly DataContext _context;
        public ProductService(DataContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }

        public List<Product> GetAll()
        {
           return _context.Products.ToList();
        }

        public Product GetById(int ProductId)
        {
            return _context.Products.Where(x => x.ProductId == ProductId).FirstOrDefault();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }
    }
}
