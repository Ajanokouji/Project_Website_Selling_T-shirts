using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppData.Migrations
{
    public partial class test01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "anhs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DuongDan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "chatLieus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenChatLieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chatLieus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "chucVus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chucVus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "giamGias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MucGiamGiaPhanTram = table.Column<double>(type: "float", nullable: false),
                    MucGiamGiaTienMat = table.Column<double>(type: "float", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_giamGias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "khachHangs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenTaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khachHangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "kichCos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kichCos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mauSacs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenMauSac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mauSacs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sanPhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanPhams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nhanViens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCV = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenTaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Anh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhanViens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nhanViens_chucVus_IdCV",
                        column: x => x.IdCV,
                        principalTable: "chucVus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gioHangs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdKH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gioHangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gioHangs_khachHangs_IdKH",
                        column: x => x.IdKH,
                        principalTable: "khachHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chiTietSanPhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdAnh = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdKC = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMS = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdLoai = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCL = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GiaNhap = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GiaBan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietSanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chiTietSanPhams_anhs_IdAnh",
                        column: x => x.IdAnh,
                        principalTable: "anhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietSanPhams_chatLieus_IdCL",
                        column: x => x.IdCL,
                        principalTable: "chatLieus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietSanPhams_kichCos_IdKC",
                        column: x => x.IdKC,
                        principalTable: "kichCos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietSanPhams_loais_IdLoai",
                        column: x => x.IdLoai,
                        principalTable: "loais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietSanPhams_mauSacs_IdMS",
                        column: x => x.IdMS,
                        principalTable: "mauSacs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietSanPhams_sanPhams_IdSP",
                        column: x => x.IdSP,
                        principalTable: "sanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hoaDons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdKH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdNV = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenNV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenKH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayShip = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    SDTNguoiNhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDTNguoiShip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TienShip = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoaDons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hoaDons_khachHangs_IdKH",
                        column: x => x.IdKH,
                        principalTable: "khachHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hoaDons_nhanViens_IdNV",
                        column: x => x.IdNV,
                        principalTable: "nhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gioHangChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCTSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    GioHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gioHangChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gioHangChiTiets_chiTietSanPhams_IdCTSP",
                        column: x => x.IdCTSP,
                        principalTable: "chiTietSanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gioHangChiTiets_gioHangs_GioHangId",
                        column: x => x.GioHangId,
                        principalTable: "gioHangs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "hoaDonChiTiets",
                columns: table => new
                {
                    IdHD = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCTSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdGiamGia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoaDonChiTiets", x => new { x.IdHD, x.IdCTSP });
                    table.ForeignKey(
                        name: "FK_hoaDonChiTiets_chiTietSanPhams_IdCTSP",
                        column: x => x.IdCTSP,
                        principalTable: "chiTietSanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hoaDonChiTiets_giamGias_IdGiamGia",
                        column: x => x.IdGiamGia,
                        principalTable: "giamGias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hoaDonChiTiets_hoaDons_IdHD",
                        column: x => x.IdHD,
                        principalTable: "hoaDons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chiTietSanPhams_IdAnh",
                table: "chiTietSanPhams",
                column: "IdAnh");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietSanPhams_IdCL",
                table: "chiTietSanPhams",
                column: "IdCL");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietSanPhams_IdKC",
                table: "chiTietSanPhams",
                column: "IdKC");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietSanPhams_IdLoai",
                table: "chiTietSanPhams",
                column: "IdLoai");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietSanPhams_IdMS",
                table: "chiTietSanPhams",
                column: "IdMS");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietSanPhams_IdSP",
                table: "chiTietSanPhams",
                column: "IdSP");

            migrationBuilder.CreateIndex(
                name: "IX_gioHangChiTiets_GioHangId",
                table: "gioHangChiTiets",
                column: "GioHangId");

            migrationBuilder.CreateIndex(
                name: "IX_gioHangChiTiets_IdCTSP",
                table: "gioHangChiTiets",
                column: "IdCTSP");

            migrationBuilder.CreateIndex(
                name: "IX_gioHangs_IdKH",
                table: "gioHangs",
                column: "IdKH");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDonChiTiets_IdCTSP",
                table: "hoaDonChiTiets",
                column: "IdCTSP");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDonChiTiets_IdGiamGia",
                table: "hoaDonChiTiets",
                column: "IdGiamGia");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDons_IdKH",
                table: "hoaDons",
                column: "IdKH");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDons_IdNV",
                table: "hoaDons",
                column: "IdNV");

            migrationBuilder.CreateIndex(
                name: "IX_nhanViens_IdCV",
                table: "nhanViens",
                column: "IdCV");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gioHangChiTiets");

            migrationBuilder.DropTable(
                name: "hoaDonChiTiets");

            migrationBuilder.DropTable(
                name: "gioHangs");

            migrationBuilder.DropTable(
                name: "chiTietSanPhams");

            migrationBuilder.DropTable(
                name: "giamGias");

            migrationBuilder.DropTable(
                name: "hoaDons");

            migrationBuilder.DropTable(
                name: "anhs");

            migrationBuilder.DropTable(
                name: "chatLieus");

            migrationBuilder.DropTable(
                name: "kichCos");

            migrationBuilder.DropTable(
                name: "loais");

            migrationBuilder.DropTable(
                name: "mauSacs");

            migrationBuilder.DropTable(
                name: "sanPhams");

            migrationBuilder.DropTable(
                name: "khachHangs");

            migrationBuilder.DropTable(
                name: "nhanViens");

            migrationBuilder.DropTable(
                name: "chucVus");
        }
    }
}
