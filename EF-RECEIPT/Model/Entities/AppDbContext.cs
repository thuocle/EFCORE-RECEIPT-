using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_RECEIPT.Model.Entities
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<LoaiNguyenLieu> LoaiNguyenLieu { get; set; }
        public virtual DbSet<NguyenLieu> NguyenLieu { get; set; }
        public virtual DbSet<ChiTietPhieuThu> ChiTietPhieuThu { get; set; }
        public virtual DbSet<PhieuThu> PhieuThu { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server = THUOCLE\\THUOCLE; Database = QuanLyReceipt; Trusted_Connection = True; " +
                $"TrustServerCertificate=True");
        }
    }
}
