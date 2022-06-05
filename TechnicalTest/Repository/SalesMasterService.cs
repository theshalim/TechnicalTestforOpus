using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTest.Data;
using TechnicalTest.Models;
using TechnicalTest.Repository.Interface;

namespace TechnicalTest.Repository
{
    public class SalesMasterService : ISalesMaster
    {
        private readonly DataContext _context;
        public SalesMasterService(DataContext context)
        {
            _context = context;
        }

        public void Add(SalesMaster salesMaster)
        {
            _context.SalesMasters.Add(salesMaster);
        }


        public void Delete(SalesMaster salesMaster)
        {
            _context.SalesMasters.Remove(salesMaster);
        }

        public List<SalesMaster> GetAll()
        {
           return _context.SalesMasters.ToList();
        }

        public SalesMaster GetById(int Id)
        {
            return _context.SalesMasters.Where(x => x.SalesMasterId == Id).FirstOrDefault();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(SalesMaster product)
        {
            _context.SalesMasters.Update(product);
        }

    }
}
