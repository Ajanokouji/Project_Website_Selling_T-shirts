using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Data
{
	public class ShopDbContext : DbContext
	{
		public ShopDbContext() { }
		public ShopDbContext(DbContextOptions options) : base(options) { }
		public DbSet<Anh> anhs { get; set; }
		public DbSet<ChatLieu> chatLieus { get; set; }
		public DbSet<ChiTietSanPham> chiTietSanPhams { get; set; }
		public DbSet<ChucVu> chucVus { get; set; }
		public DbSet<GiamGia> giamGias { get; set; }
		public DbSet<GioHang> gioHangs { get; set; }
		public DbSet<GioHangChiTiet> gioHangChiTiets { get; set; }
		public DbSet<HoaDon> hoaDons { get; set; }
		public DbSet<HoaDonChiTiet> hoaDonChiTiets { get; set; }
		public DbSet<KhachHang> khachHangs { get; set; }
		public DbSet<KichCo> kichCos { get; set; }
		public DbSet<Loai> loais { get; set; }
		public DbSet<MauSac> mauSacs { get; set; }
		public DbSet<NhanVien> nhanViens { get; set; }
		public DbSet<SanPham> sanPhams { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=Website_Tshirt;Persist Security Info=True;User ID=PH26922;Password=tri01637126999");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Anh>(e =>
			{
				e.HasKey(e => e.Id);
			});
			modelBuilder.Entity<ChatLieu>(e =>
			{
				e.HasKey(e => e.Id);
			}); 
			modelBuilder.Entity<ChiTietSanPham>(e =>
			{
				e.HasKey(e => e.Id);
				e.HasOne(e => e.sanPham).WithMany(e => e.chiTietSanPhams).HasForeignKey(e => e.IdSP);
				e.HasOne(e => e.anh).WithMany(e => e.chiTietSanPhams).HasForeignKey(e => e.IdAnh);
				e.HasOne(e => e.kichCo).WithMany(e => e.chiTietSanPhams).HasForeignKey(e => e.IdKC);
				e.HasOne(e => e.mauSac).WithMany(e => e.chiTietSanPhams).HasForeignKey(e => e.IdMS);
				e.HasOne(e => e.loai).WithMany(e => e.chiTietSanPhams).HasForeignKey(e => e.IdLoai);
				e.HasOne(e => e.chatLieu).WithMany(e => e.chiTietSanPhams).HasForeignKey(e => e.IdCL);
			}); 
			modelBuilder.Entity<ChucVu>(e =>
			{
				e.HasKey(e => e.Id);
			});
			modelBuilder.Entity<GiamGia>(e =>
			{
				e.HasKey(e => e.Id);
			}); 
			modelBuilder.Entity<GioHang>(e =>
			{
				e.HasKey(e => e.Id);
				e.HasOne(e => e.khachHang).WithMany(e => e.gioHangs).HasForeignKey(e => e.IdKH);
			});			
			modelBuilder.Entity<GioHangChiTiet>(e =>
			{
				e.HasKey(e => e.Id);
				e.HasOne(e => e.chiTietSanPham).WithMany(e => e.gioHangChiTiets).HasForeignKey(e => e.IdCTSP);
			});			
			modelBuilder.Entity<HoaDon>(e =>
			{
				e.HasKey(e => e.Id);
				e.HasOne(e => e.khachHang).WithMany(e => e.hoaDons).HasForeignKey(e => e.IdKH);
				e.HasOne(e => e.nhanVien).WithMany(e => e.hoaDons).HasForeignKey(e => e.IdNV);
			});			
			modelBuilder.Entity<HoaDonChiTiet>(e =>
			{
				e.HasKey(e => new {e.IdHD, e.IdCTSP});
				e.HasOne(e => e.hoaDon).WithMany(e => e.hoaDonChiTiets).HasForeignKey(e => e.IdHD);
				e.HasOne(e => e.chiTietSanPham).WithMany(e => e.hoaDonChiTiets).HasForeignKey(e => e.IdCTSP);
				e.HasOne(e => e.giamGia).WithMany(e => e.hoaDonChiTiets).HasForeignKey(e => e.IdGiamGia);
			});			
			modelBuilder.Entity<KhachHang>(e =>
			{
				e.HasKey(e => e.Id);
			});			
			modelBuilder.Entity<KichCo>(e =>
			{
				e.HasKey(e => e.Id);
			});			
			modelBuilder.Entity<Loai>(e =>
			{
				e.HasKey(e => e.Id);
			});			
			modelBuilder.Entity<MauSac>(e =>
			{
				e.HasKey(e => e.Id);
			});			
			modelBuilder.Entity<NhanVien>(e =>
			{
				e.HasKey(e => e.Id);
				e.HasOne(e => e.chucVu).WithMany(e => e.nhanViens).HasForeignKey(e => e.IdCV);
			});			
			modelBuilder.Entity<SanPham>(e =>
			{
				e.HasKey(e => e.Id);
			});
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
