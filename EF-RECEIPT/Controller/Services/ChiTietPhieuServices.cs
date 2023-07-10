using EF_RECEIPT.Controller.IServices;
using EF_RECEIPT.Model.Entities;
using EF_RECEIPT.Model.Helper;
using System.ComponentModel;
using System.Xml;

namespace EF_RECEIPT.Controller.Services
{
    public class ChiTietPhieuServices : IChiTietPhieuServices
    {
        private readonly AppDbContext dbContext;

        public ChiTietPhieuServices()
        {
            this.dbContext = new AppDbContext();
        }
        #region Private method
        private PhieuThu isReceipt(int phieuId)
        {
            return dbContext.PhieuThu.FirstOrDefault(x => x.PhieuThuID == phieuId);
        }
        private NguyenLieu isIngredient(ChiTietPhieuThu ct)
        {
            return dbContext.NguyenLieu.FirstOrDefault(x => x.NguyenLieuID == ct.NguyenLieuID);
        }
        private bool checkIngredientExistence(ChiTietPhieuThu ct)
        {
            var nl = dbContext.ChiTietPhieuThu.FirstOrDefault(x => x.PhieuThuID == ct.PhieuThuID && x.NguyenLieuID== ct.NguyenLieuID);
            return  nl != null;
        }
        private bool CheckQuantityBeforeAdd(ChiTietPhieuThu ct)
        {
            var ngl = dbContext.NguyenLieu.FirstOrDefault(x => x.NguyenLieuID == ct.NguyenLieuID);
            return ngl.SoLuongKho >= ct.SoLuongBan;
        }
        private void UpdateQuantity(ChiTietPhieuThu ct)
        {
            var nglieu = dbContext.NguyenLieu.FirstOrDefault(x => x.NguyenLieuID == ct.NguyenLieuID);
            if (nglieu != null)
            {
                nglieu.SoLuongKho -= ct.SoLuongBan;
                dbContext.Update(nglieu);
                dbContext.SaveChanges();
            }
        }
        private void updateReceiptTotalAmount(ChiTietPhieuThu ct)
        {
            var phieu = dbContext.PhieuThu.FirstOrDefault(x => x.PhieuThuID == ct.PhieuThuID);
            var nglieu = dbContext.NguyenLieu.FirstOrDefault(x => x.NguyenLieuID == ct.NguyenLieuID);
            if (phieu != null && nglieu != null)
            {
                phieu.ThanhTien += (nglieu.GiaBan * ct.SoLuongBan);
                dbContext.Update(phieu);
                dbContext.SaveChanges();
            }
        }
        #endregion
        public void addListReceiptDetail(int phieuID)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    if(isReceipt(phieuID) == null)
                    {
                        Console.WriteLine("Phieu thu " + Res.KhongTonTai);
                        Console.WriteLine(Res.ThatBai);
                        return;
                    }
                    Console.WriteLine("Nhap so nguyen lieu cho chi tiet phieu: ");
                    int so = InputHelper.InputINT("Nhap so: ", Res.Err);
                    for (int i = 0; i < so; i++)
                    {
                        var ct = new ChiTietPhieuThu(inputType.Them) { PhieuThuID = phieuID };
                        if(CheckQuantityBeforeAdd(ct) && isIngredient(ct) != null && !checkIngredientExistence(ct))
                        {
                            dbContext.Add(ct);
                            dbContext.SaveChanges();
                            UpdateQuantity(ct);
                            updateReceiptTotalAmount(ct);
                        }
                        else
                        {
                            Console.WriteLine(Res.Err);
                            Console.WriteLine(Res.ThatBai);
                            return;
                        }
                    }
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
