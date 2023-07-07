using EF_RECEIPT.Controller.IServices;
using EF_RECEIPT.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_RECEIPT.Controller.Services
{
    public class PhieuThuServices : IPhieuThuServices
    {
        private readonly AppDbContext dbContext;

        public PhieuThuServices()
        {
            this.dbContext = new AppDbContext();
        }
        public void addReceipt(PhieuThu p)
        {
           using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    dbContext.Add(p);
                    dbContext.SaveChanges();
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
    }
}
