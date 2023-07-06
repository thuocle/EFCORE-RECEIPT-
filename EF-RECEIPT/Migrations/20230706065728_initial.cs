using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_RECEIPT.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiNguyenLieu",
                columns: table => new
                {
                    LoaiNguyenLieuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiNguyenLieu", x => x.LoaiNguyenLieuID);
                });

            migrationBuilder.CreateTable(
                name: "PhieuThu",
                columns: table => new
                {
                    PhieuThuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayLap = table.Column<int>(type: "int", nullable: false),
                    NhanVienLap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThanhTien = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuThu", x => x.PhieuThuID);
                });

            migrationBuilder.CreateTable(
                name: "NguyenLieu",
                columns: table => new
                {
                    NguyenLieuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiNguyenLieuID = table.Column<int>(type: "int", nullable: false),
                    TenNguyenLieu = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GiaBan = table.Column<double>(type: "float", nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SoLuongKho = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguyenLieu", x => x.NguyenLieuID);
                    table.ForeignKey(
                        name: "FK_NguyenLieu_LoaiNguyenLieu_LoaiNguyenLieuID",
                        column: x => x.LoaiNguyenLieuID,
                        principalTable: "LoaiNguyenLieu",
                        principalColumn: "LoaiNguyenLieuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuThu",
                columns: table => new
                {
                    ChiTietPhieuThuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguyenLieuID = table.Column<int>(type: "int", nullable: false),
                    PhieuThuID = table.Column<int>(type: "int", nullable: false),
                    SoLuongBan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuThu", x => x.ChiTietPhieuThuID);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuThu_NguyenLieu_NguyenLieuID",
                        column: x => x.NguyenLieuID,
                        principalTable: "NguyenLieu",
                        principalColumn: "NguyenLieuID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuThu_PhieuThu_PhieuThuID",
                        column: x => x.PhieuThuID,
                        principalTable: "PhieuThu",
                        principalColumn: "PhieuThuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuThu_NguyenLieuID",
                table: "ChiTietPhieuThu",
                column: "NguyenLieuID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuThu_PhieuThuID",
                table: "ChiTietPhieuThu",
                column: "PhieuThuID");

            migrationBuilder.CreateIndex(
                name: "IX_NguyenLieu_LoaiNguyenLieuID",
                table: "NguyenLieu",
                column: "LoaiNguyenLieuID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietPhieuThu");

            migrationBuilder.DropTable(
                name: "NguyenLieu");

            migrationBuilder.DropTable(
                name: "PhieuThu");

            migrationBuilder.DropTable(
                name: "LoaiNguyenLieu");
        }
    }
}
