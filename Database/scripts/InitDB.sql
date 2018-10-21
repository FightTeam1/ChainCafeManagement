USE [QL_ChuoiQuanCafe]
GO
/****** Object:  Table [dbo].[CHITIETHOADON]    Script Date: 10/21/2018 6:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETHOADON](
	[MAHOADON] [varchar](10) NOT NULL,
	[MASP] [varchar](10) NOT NULL,
	[SL_SP] [int] NULL,
 CONSTRAINT [PK_CHITIETHOADON] PRIMARY KEY CLUSTERED 
(
	[MAHOADON] ASC,
	[MASP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHITIETPHIEUNHAP]    Script Date: 10/21/2018 6:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETPHIEUNHAP](
	[MAPHIEU] [varchar](10) NOT NULL,
	[MADVT] [varchar](10) NOT NULL,
	[MANGUYENLIEU] [varchar](10) NOT NULL,
	[SL] [int] NULL,
	[QUYDOI] [float] NULL,
	[DONGIA] [numeric](8, 2) NULL,
 CONSTRAINT [PK_CHITIETPHIEUNHAP] PRIMARY KEY CLUSTERED 
(
	[MAPHIEU] ASC,
	[MADVT] ASC,
	[MANGUYENLIEU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COSO]    Script Date: 10/21/2018 6:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COSO](
	[MACS] [varchar](10) NOT NULL,
	[TENCS] [nvarchar](100) NULL,
	[DIACHI] [nvarchar](100) NULL,
	[SDT] [varchar](10) NULL,
 CONSTRAINT [PK_COSO] PRIMARY KEY CLUSTERED 
(
	[MACS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DSMANHINH]    Script Date: 10/21/2018 6:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DSMANHINH](
	[MAMANHINH] [varchar](10) NOT NULL,
	[TENMANHINH] [nvarchar](50) NULL,
 CONSTRAINT [PK_DSMANHINH] PRIMARY KEY CLUSTERED 
(
	[MAMANHINH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DVT]    Script Date: 10/21/2018 6:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DVT](
	[MADVT] [varchar](10) NOT NULL,
	[TENDVT] [nvarchar](50) NULL,
 CONSTRAINT [PK_DVT] PRIMARY KEY CLUSTERED 
(
	[MADVT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 10/21/2018 6:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[MAHOADON] [varchar](10) NOT NULL,
	[MANV] [varchar](10) NULL,
	[TENDANGNHAP] [varchar](20) NULL,
	[NGAYGIOLAP] [datetime] NULL,
	[THANHTIEN] [numeric](8, 2) NULL,
	[TRANGTHAI] [nvarchar](50) NULL,
	[DIACHI] [nvarchar](100) NULL,
 CONSTRAINT [PK_HOADON] PRIMARY KEY CLUSTERED 
(
	[MAHOADON] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 10/21/2018 6:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[TENDANGNHAP] [varchar](20) NOT NULL,
	[HOTENKH] [nvarchar](50) NULL,
	[SDT] [varchar](10) NULL,
	[EMAIL] [varchar](30) NULL,
	[DIEMTICH] [int] NULL,
	[MATKHAU] [varchar](100) NULL,
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[TENDANGNHAP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAINHANVIEN]    Script Date: 10/21/2018 6:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAINHANVIEN](
	[MALOAINV] [varchar](10) NOT NULL,
	[TENLOAINV] [nvarchar](50) NULL,
 CONSTRAINT [PK_LOAINHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MALOAINV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAINHANVIEN_NHOMQUYEN]    Script Date: 10/21/2018 6:47:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAINHANVIEN_NHOMQUYEN](
	[MALOAINV] [varchar](10) NOT NULL,
	[MANHOM] [varchar](10) NOT NULL,
 CONSTRAINT [PK_LOAINHANVIEN_NHOMQUYEN] PRIMARY KEY CLUSTERED 
(
	[MALOAINV] ASC,
	[MANHOM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAISP]    Script Date: 10/21/2018 6:47:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAISP](
	[MALOAISP] [varchar](10) NOT NULL,
	[TENLOAISP] [nvarchar](100) NOT NULL,
	[HinhAnh] [nvarchar](100) NULL,
 CONSTRAINT [PK_LOAISP] PRIMARY KEY CLUSTERED 
(
	[MALOAISP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NGUYENLIEU]    Script Date: 10/21/2018 6:47:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NGUYENLIEU](
	[MANGUYENLIEU] [varchar](10) NOT NULL,
	[TENNGUYENLIEU] [nvarchar](50) NULL,
	[DVT_NHO] [varchar](10) NULL,
 CONSTRAINT [PK_NGUYENLIEU] PRIMARY KEY CLUSTERED 
(
	[MANGUYENLIEU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 10/21/2018 6:47:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MANV] [varchar](10) NOT NULL,
	[MALOAINV] [varchar](10) NULL,
	[MACS] [varchar](10) NULL,
	[HOTENNV] [nvarchar](50) NULL,
	[SDT_NV] [varchar](50) NULL,
	[CMND] [varchar](20) NULL,
	[EMAIL] [varchar](30) NULL,
	[DIACHI_NV] [nvarchar](100) NULL,
	[MATKHAU] [varchar](100) NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MANV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHOMQUYEN]    Script Date: 10/21/2018 6:47:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHOMQUYEN](
	[MANHOM] [varchar](10) NOT NULL,
	[TENNHOM] [nvarchar](100) NULL,
 CONSTRAINT [PK_NHOMQUYEN] PRIMARY KEY CLUSTERED 
(
	[MANHOM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHANQUYEN]    Script Date: 10/21/2018 6:47:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHANQUYEN](
	[MAMANHINH] [varchar](10) NOT NULL,
	[MANHOM] [varchar](10) NOT NULL,
 CONSTRAINT [PK_PHANQUYEN] PRIMARY KEY CLUSTERED 
(
	[MAMANHINH] ASC,
	[MANHOM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEUNHAP]    Script Date: 10/21/2018 6:47:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUNHAP](
	[MAPHIEU] [varchar](10) NOT NULL,
	[MANV] [varchar](10) NULL,
	[NGAYNHAP] [datetime] NULL,
	[TRANGTHAI] [nvarchar](50) NULL,
	[TONGGIA] [numeric](8, 2) NULL,
 CONSTRAINT [PK_PHIEUNHAP] PRIMARY KEY CLUSTERED 
(
	[MAPHIEU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SANPHAM]    Script Date: 10/21/2018 6:47:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SANPHAM](
	[MASP] [varchar](10) NOT NULL,
	[MALOAISP] [varchar](10) NULL,
	[TENSP] [nvarchar](100) NULL,
	[DONGIA] [numeric](8, 2) NULL,
	[HinhAnh] [nvarchar](100) NULL,
 CONSTRAINT [PK_SANPHAM] PRIMARY KEY CLUSTERED 
(
	[MASP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SP_NGUYENLIEU]    Script Date: 10/21/2018 6:47:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SP_NGUYENLIEU](
	[MASP] [varchar](10) NOT NULL,
	[MANGUYENLIEU] [varchar](10) NOT NULL,
	[SL_DVT_NHO] [int] NULL,
 CONSTRAINT [PK_SP_NGUYENLIEU] PRIMARY KEY CLUSTERED 
(
	[MASP] ASC,
	[MANGUYENLIEU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TINTUC]    Script Date: 10/21/2018 6:47:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TINTUC](
	[MATIN] [varchar](10) NOT NULL,
	[TIEUDE] [nvarchar](50) NOT NULL,
	[NOIDUNG] [nvarchar](1000) NULL,
	[HINHANH] [nvarchar](100) NULL,
	[MANV] [varchar](10) NULL,
	[NGAYDANG] [datetime] NULL,
 CONSTRAINT [PK_TINTUC] PRIMARY KEY CLUSTERED 
(
	[MATIN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TONKHO]    Script Date: 10/21/2018 6:47:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TONKHO](
	[MANGUYENLIEU] [varchar](10) NOT NULL,
	[MACS] [varchar](10) NOT NULL,
	[SL] [int] NULL,
 CONSTRAINT [PK_TONKHO] PRIMARY KEY CLUSTERED 
(
	[MANGUYENLIEU] ASC,
	[MACS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETH_CHITIETHO_HOADON] FOREIGN KEY([MAHOADON])
REFERENCES [dbo].[HOADON] ([MAHOADON])
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [FK_CHITIETH_CHITIETHO_HOADON]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETH_CHITIETHO_SANPHAM] FOREIGN KEY([MASP])
REFERENCES [dbo].[SANPHAM] ([MASP])
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [FK_CHITIETH_CHITIETHO_SANPHAM]
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETP_CHITIETPH_DVT] FOREIGN KEY([MADVT])
REFERENCES [dbo].[DVT] ([MADVT])
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP] CHECK CONSTRAINT [FK_CHITIETP_CHITIETPH_DVT]
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETP_CHITIETPH_NGUYENLI] FOREIGN KEY([MANGUYENLIEU])
REFERENCES [dbo].[NGUYENLIEU] ([MANGUYENLIEU])
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP] CHECK CONSTRAINT [FK_CHITIETP_CHITIETPH_NGUYENLI]
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETP_CHITIETPH_PHIEUNHA] FOREIGN KEY([MAPHIEU])
REFERENCES [dbo].[PHIEUNHAP] ([MAPHIEU])
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP] CHECK CONSTRAINT [FK_CHITIETP_CHITIETPH_PHIEUNHA]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_KHACHHANG_KHACHHAN] FOREIGN KEY([TENDANGNHAP])
REFERENCES [dbo].[KHACHHANG] ([TENDANGNHAP])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON_KHACHHANG_KHACHHAN]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_NHANVIEN__NHANVIEN] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON_NHANVIEN__NHANVIEN]
GO
ALTER TABLE [dbo].[LOAINHANVIEN_NHOMQUYEN]  WITH CHECK ADD  CONSTRAINT [FK_LOAINHAN_LOAINHANV_LOAINHAN] FOREIGN KEY([MALOAINV])
REFERENCES [dbo].[LOAINHANVIEN] ([MALOAINV])
GO
ALTER TABLE [dbo].[LOAINHANVIEN_NHOMQUYEN] CHECK CONSTRAINT [FK_LOAINHAN_LOAINHANV_LOAINHAN]
GO
ALTER TABLE [dbo].[LOAINHANVIEN_NHOMQUYEN]  WITH CHECK ADD  CONSTRAINT [FK_LOAINHAN_LOAINHANV_NHOMQUYE] FOREIGN KEY([MANHOM])
REFERENCES [dbo].[NHOMQUYEN] ([MANHOM])
GO
ALTER TABLE [dbo].[LOAINHANVIEN_NHOMQUYEN] CHECK CONSTRAINT [FK_LOAINHAN_LOAINHANV_NHOMQUYE]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_NHANVIEN_COSO_NHAN_COSO] FOREIGN KEY([MACS])
REFERENCES [dbo].[COSO] ([MACS])
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [FK_NHANVIEN_COSO_NHAN_COSO]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_NHANVIEN_LOAINV_NH_LOAINHAN] FOREIGN KEY([MALOAINV])
REFERENCES [dbo].[LOAINHANVIEN] ([MALOAINV])
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [FK_NHANVIEN_LOAINV_NH_LOAINHAN]
GO
ALTER TABLE [dbo].[PHANQUYEN]  WITH CHECK ADD  CONSTRAINT [FK_PHANQUYE_PHANQUYEN_DSMANHIN] FOREIGN KEY([MAMANHINH])
REFERENCES [dbo].[DSMANHINH] ([MAMANHINH])
GO
ALTER TABLE [dbo].[PHANQUYEN] CHECK CONSTRAINT [FK_PHANQUYE_PHANQUYEN_DSMANHIN]
GO
ALTER TABLE [dbo].[PHANQUYEN]  WITH CHECK ADD  CONSTRAINT [FK_PHANQUYE_PHANQUYEN_NHOMQUYE] FOREIGN KEY([MANHOM])
REFERENCES [dbo].[NHOMQUYEN] ([MANHOM])
GO
ALTER TABLE [dbo].[PHANQUYEN] CHECK CONSTRAINT [FK_PHANQUYE_PHANQUYEN_NHOMQUYE]
GO
ALTER TABLE [dbo].[PHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUNHA_NHANVIEN__NHANVIEN] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[PHIEUNHAP] CHECK CONSTRAINT [FK_PHIEUNHA_NHANVIEN__NHANVIEN]
GO
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_SANPHAM_LOAISP_SA_LOAISP] FOREIGN KEY([MALOAISP])
REFERENCES [dbo].[LOAISP] ([MALOAISP])
GO
ALTER TABLE [dbo].[SANPHAM] CHECK CONSTRAINT [FK_SANPHAM_LOAISP_SA_LOAISP]
GO
ALTER TABLE [dbo].[SP_NGUYENLIEU]  WITH CHECK ADD  CONSTRAINT [FK_SP_NGUYE_SP_NGUYEN_NGUYENLI] FOREIGN KEY([MANGUYENLIEU])
REFERENCES [dbo].[NGUYENLIEU] ([MANGUYENLIEU])
GO
ALTER TABLE [dbo].[SP_NGUYENLIEU] CHECK CONSTRAINT [FK_SP_NGUYE_SP_NGUYEN_NGUYENLI]
GO
ALTER TABLE [dbo].[SP_NGUYENLIEU]  WITH CHECK ADD  CONSTRAINT [FK_SP_NGUYE_SP_NGUYEN_SANPHAM] FOREIGN KEY([MASP])
REFERENCES [dbo].[SANPHAM] ([MASP])
GO
ALTER TABLE [dbo].[SP_NGUYENLIEU] CHECK CONSTRAINT [FK_SP_NGUYE_SP_NGUYEN_SANPHAM]
GO
ALTER TABLE [dbo].[TINTUC]  WITH CHECK ADD  CONSTRAINT [FK_TINTUC_NHANVIEN] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[TINTUC] CHECK CONSTRAINT [FK_TINTUC_NHANVIEN]
GO
ALTER TABLE [dbo].[TONKHO]  WITH CHECK ADD  CONSTRAINT [FK_TONKHO_TONKHO_NGUYENLI] FOREIGN KEY([MANGUYENLIEU])
REFERENCES [dbo].[NGUYENLIEU] ([MANGUYENLIEU])
GO
ALTER TABLE [dbo].[TONKHO] CHECK CONSTRAINT [FK_TONKHO_TONKHO_NGUYENLI]
GO
ALTER TABLE [dbo].[TONKHO]  WITH CHECK ADD  CONSTRAINT [FK_TONKHO_TONKHO2_COSO] FOREIGN KEY([MACS])
REFERENCES [dbo].[COSO] ([MACS])
GO
ALTER TABLE [dbo].[TONKHO] CHECK CONSTRAINT [FK_TONKHO_TONKHO2_COSO]
GO
