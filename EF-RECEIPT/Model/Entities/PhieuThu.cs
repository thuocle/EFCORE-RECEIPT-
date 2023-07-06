﻿using System;
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
    }
}