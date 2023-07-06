using EF_RECEIPT.Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_RECEIPT.Model.Entities
{
    public class NguyenLieu
    {
        public int NguyenLieuID { get; set; }
        public int LoaiNguyenLieuID { get; set; }
        public LoaiNguyenLieu LoaiNguyenLieu { get; set; }
        [MaxLength(20)]
        public string TenNguyenLieu { get; set; }
        public double GiaBan { get; set; }
        [MaxLength(20)]
        public string DonViTinh { get; set; }
        public int SoLuongKho { get; set; }
        public IEnumerable<ChiTietPhieuThu> ChiTietPhieuThu { get; set; }
        public NguyenLieu(inputType it)
        {
            if(it == inputType.Them)
            {
                LoaiNguyenLieuID = InputHelper.InputINT(Res.LoaiNguyenLieuID, Res.Err);
                TenNguyenLieu = InputHelper.InputSTR(Res.TenNguyenLieu, Res.Err, 1, 20);
                GiaBan = InputHelper.InputDB(Res.GiaBan, Res.Err);
                DonViTinh = InputHelper.InputSTR(Res.DonViTinh, Res.Err, 1, 10);
                SoLuongKho = InputHelper.InputINT(Res.SoLuongKho, Res.Err);
            }
        } 
        public NguyenLieu()
        {
            
        }
    }
}
