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
    }
}
