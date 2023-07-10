using EF_RECEIPT.Controller.IServices;
using EF_RECEIPT.Model.Entities;
using EF_RECEIPT.Model.Helper;

namespace EF_RECEIPT.Controller.Services
{
    public class PhieuThuServices : IPhieuThuServices
    {
        private readonly AppDbContext dbContext;

        public PhieuThuServices()
        {
            this.dbContext = new AppDbContext();
        }
        private PhieuThu isReceipt(int phieuId)
        {
            return dbContext.PhieuThu.FirstOrDefault(x => x.PhieuThuID == phieuId);
        }
        public void addReceipt(PhieuThu p)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    dbContext.Add(p);
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

        public void deleteReceipt(int phieuID)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (isReceipt(phieuID) == null)
                    {
                        Console.WriteLine(Res.KhongTonTai);
                        Console.WriteLine(Res.ThatBai);
                        return;
                    }
                    dbContext.Remove(isReceipt(phieuID));
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

        public void getReceiptsByDate()
        {
            var query = from loai in dbContext.LoaiNguyenLieu
                        join nglieu in dbContext.NguyenLieu on loai.LoaiNguyenLieuID equals nglieu.LoaiNguyenLieuID
                        join chitiet in dbContext.ChiTietPhieuThu on nglieu.NguyenLieuID equals chitiet.NguyenLieuID
                        join phieu in dbContext.PhieuThu on chitiet.PhieuThuID equals phieu.PhieuThuID
                        group new { loai, nglieu, chitiet, phieu }
                        by phieu.NgayLap into gByDate
                        orderby gByDate.Key.Date
                        select new
                        {
                            NgayThu = gByDate.Key.ToString("dd - MMMM - yyyy"),

                            DSPhieu = from p in gByDate
                                      group new { p.chitiet, p.nglieu } by new { p.phieu.PhieuThuID, p.phieu.ThanhTien } into gPhieu
                                      select new
                                      {
                                          phieuID = gPhieu.Key.PhieuThuID,
                                          ct = gPhieu.Select(x => new { ten = x.nglieu.TenNguyenLieu, sl = x.chitiet.SoLuongBan }),
                                          TT = gPhieu.Key.ThanhTien
                                      }
                        };
            foreach (var item in query)
            {
                Console.WriteLine("Ngay "+item.NgayThu+"\n");
                foreach (var item2 in item.DSPhieu)
                {
                    Console.WriteLine("Phieu thu " + item2.phieuID);
                    foreach (var item3 in item2.ct)
                    {
                        Console.WriteLine($"- {item3.ten} - SLBan: {item3.sl}");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
