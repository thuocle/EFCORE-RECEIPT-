using EF_RECEIPT.Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_RECEIPT.Model.Entities
{
    public class ChiTietPhieuThu
    {
        public int ChiTietPhieuThuID { get; set; }
        public int NguyenLieuID { get; set; }
        public NguyenLieu NguyenLieu { get; set; }  
        public int PhieuThuID { get; set; }
        public PhieuThu PhieuThu { get; set; }
        public int SoLuongBan { get; set; }

        public ChiTietPhieuThu(inputType it)
        {
            if(it == inputType.Them)
            {
                NguyenLieuID = InputHelper.InputINT(Res.NguyenLieuID, Res.Err);
                SoLuongBan = InputHelper.InputINT(Res.SoLuongBan, Res.Err);

            }
        }
        public ChiTietPhieuThu()
        {
            
        }
    }
}
