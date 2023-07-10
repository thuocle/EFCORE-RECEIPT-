using EF_RECEIPT.Controller.IServices;
using EF_RECEIPT.Model.Entities;
using EF_RECEIPT.Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_RECEIPT.Controller.Services
{
    public class NguyenLieuServices : INguyenLieuServices
    {
        private readonly AppDbContext dbContext;

        public NguyenLieuServices()
        {
            this.dbContext = new AppDbContext();
        }
        private LoaiNguyenLieu isIngredient(int nlID)
        {
            return dbContext.LoaiNguyenLieu.FirstOrDefault(x => x.LoaiNguyenLieuID == nlID);
        }
        public void addIngredient(NguyenLieu nl)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (!InputHelper.CheckNguyenLieuRule(nl))
                    {
                        Console.WriteLine(Res.Err);
                        Console.WriteLine(Res.ThatBai);
                        return;
                    }
                    if(isIngredient(nl.LoaiNguyenLieuID)== null)
                    {
                        Console.WriteLine(Res.KhongTonTai);
                        Console.WriteLine(Res.ThatBai);
                        return;
                    }
                    dbContext.Add(nl);
                    dbContext.SaveChanges();
                    Console.WriteLine(Res.ThanhCong);
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
