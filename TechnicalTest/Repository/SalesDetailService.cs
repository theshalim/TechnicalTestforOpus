using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTest.Data;
using TechnicalTest.Models;
using TechnicalTest.Repository.Interface;

namespace TechnicalTest.Repository
{
    public class SalesDetailService : ISalesDetail
    {
        private readonly DataContext _context;
        public SalesDetailService(DataContext context)
        {
            _context = context;
        }

        public void Add(SalesDetail salesDetail)
        {
            _context.SalesDetails.Add(salesDetail);
        }

        public void Delete(SalesDetail salesDetail)
        {
            _context.SalesDetails.Remove(salesDetail);
        }

        public List<SalesDetail> GetAll()
        {
          return _context.SalesDetails.ToList();
        }

        public SalesDetail GetById(int Id)
        {
            return _context.SalesDetails.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(SalesDetail salesDetail)
        {
            _context.SalesDetails.Update(salesDetail);
        }
    }
}
