using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_RECEIPT.Model.Entities
{
    public class LoaiNguyenLieu
    {
        public int LoaiNguyenLieuID { get; set; }
        [MaxLength(20)]
        public string TenLoai { get; set; }
        [MaxLength(int.MaxValue)]
        public string MoTa { get; set; }
    }
}
