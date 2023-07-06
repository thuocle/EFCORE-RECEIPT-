using EF_RECEIPT.Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_RECEIPT.Model.Entities
{
    public class PhieuThu
    {
        public int PhieuThuID { get; set; }
        public int NgayLap { get; set; }
        public string NhanVienLap { get; set; }
        public string GhiChu { get; set; }
        public double ThanhTien { get; set; }
        public IEnumerable<ChiTietPhieuThu> ChiTietPhieuThu { get; set; }
        public PhieuThu(inputType it)
        {
            if (it == inputType.Them)
            {
                NgayLap = InputHelper.InputINT(Res.NgayLap, Res.Err);
                NhanVienLap = InputHelper.InputSTR(Res.NhanVienLap, Res.Err);
                GhiChu = InputHelper.InputSTR(Res.GhiChu, Res.Err);
            }
        }
        public PhieuThu()
        {
            
        }
    }
}
