create database [FruitShop]
go
USE [FruitShop]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 12/17/2024 7:17:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[type] [nvarchar](50) NOT NULL,
	[email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 12/17/2024 7:17:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[cate_id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[cate_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 12/17/2024 7:17:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[customer_id] [int] IDENTITY(1,1) NOT NULL,
	[customer_name] [nvarchar](50) NULL,
	[state] [nvarchar](max) NULL,
	[phone] [nvarchar](50) NULL,
	[note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detail_ExportBill]    Script Date: 12/17/2024 7:17:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detail_ExportBill](
	[export_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[quantity] [float] NULL,
	[total_price] [float] NULL,
	[discount] [float] NULL,
 CONSTRAINT [PK_Detail_ExportBill] PRIMARY KEY CLUSTERED 
(
	[export_id] ASC,
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detail_ImportBill]    Script Date: 12/17/2024 7:17:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detail_ImportBill](
	[import_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[quantity] [float] NULL,
	[priceAitem] [float] NULL,
	[total_price] [float] NULL,
 CONSTRAINT [PK_Detail_ImportBill] PRIMARY KEY CLUSTERED 
(
	[import_id] ASC,
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExportBill]    Script Date: 12/17/2024 7:17:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExportBill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[export_date] [datetime] NULL,
	[staff_id] [nvarchar](50) NULL,
	[customer_id] [int] NULL,
	[total_price] [float] NULL,
	[note] [nvarchar](max) NULL,
 CONSTRAINT [PK_ExportBill] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImportBill]    Script Date: 12/17/2024 7:17:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportBill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[import_date] [datetime] NULL,
	[staff_id] [nvarchar](50) NULL,
	[suplier_id] [int] NULL,
	[total_price] [float] NULL,
 CONSTRAINT [PK_Import Bill] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orderDetais]    Script Date: 12/17/2024 7:17:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orderDetais](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NULL,
	[sanpham_id] [int] NULL,
	[soluong] [int] NULL,
	[tongtien] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orders]    Script Date: 12/17/2024 7:17:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ten] [nvarchar](100) NULL,
	[statuc] [int] NULL,
	[ngaytao] [datetime] NULL,
	[users_id] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 12/17/2024 7:17:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[product_name] [nvarchar](500) NULL,
	[price_import] [float] NULL,
	[price_sale] [float] NULL,
	[quantity] [float] NULL,
	[category_id] [int] NULL,
	[image] [nvarchar](500) NULL,
	[status_id] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 12/17/2024 7:17:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[staff_id] [nvarchar](50) NOT NULL,
	[staff_name] [nvarchar](50) NULL,
	[dateOfBirth] [date] NULL,
	[gender] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[note] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 12/17/2024 7:17:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[status_id] [int] IDENTITY(1,1) NOT NULL,
	[status_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[status_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suplier]    Script Date: 12/17/2024 7:17:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suplier](
	[suplier_id] [int] IDENTITY(1,1) NOT NULL,
	[suplier_name] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[phone] [nvarchar](50) NULL,
 CONSTRAINT [PK_Suplier] PRIMARY KEY CLUSTERED 
(
	[suplier_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([username], [password], [type], [email]) VALUES (N'admin', N'123456', N'1', N'admin@gmail.com')
INSERT [dbo].[Account] ([username], [password], [type], [email]) VALUES (N'admin1', N'e10adc3949ba59abbe56e057f20f883e', N'admin', N'a@gmail.com')
INSERT [dbo].[Account] ([username], [password], [type], [email]) VALUES (N'hoang', N'123456', N'1', N'hoang@gmail.com')
INSERT [dbo].[Account] ([username], [password], [type], [email]) VALUES (N'kien', N'123456', N'1', N'kien@gmail.com')
INSERT [dbo].[Account] ([username], [password], [type], [email]) VALUES (N'phong', N'123456', N'1', N'phong@gmail.com')
INSERT [dbo].[Account] ([username], [password], [type], [email]) VALUES (N'staff', N'staff', N'0', N'staff@gmail.com')
INSERT [dbo].[Account] ([username], [password], [type], [email]) VALUES (N'tuan', N'123456', N'1', N'tuan@gmail.com')
INSERT [dbo].[Account] ([username], [password], [type], [email]) VALUES (N'viet', N'123456', N'1', N'viet123@gmail.com')
INSERT [dbo].[Account] ([username], [password], [type], [email]) VALUES (N'yasuo', N'123456', N'0', N'yasuo@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([cate_id], [category_name]) VALUES (1, N'Hoa quả Nam bộ')
INSERT [dbo].[Category] ([cate_id], [category_name]) VALUES (2, N'Hoa quả Bắc bộ')
INSERT [dbo].[Category] ([cate_id], [category_name]) VALUES (3, N'Hoa quả nhập khẩu')
INSERT [dbo].[Category] ([cate_id], [category_name]) VALUES (4, N'Hoa quả VietGap')
INSERT [dbo].[Category] ([cate_id], [category_name]) VALUES (5, N'Hoa quả nông trại hữu cơ')
INSERT [dbo].[Category] ([cate_id], [category_name]) VALUES (6, N'Hoa quả chính vụ')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([customer_id], [customer_name], [state], [phone], [note]) VALUES (1, N'Võ Khắc Việt', N'Hà Nội', N'0938434254', N'none')
INSERT [dbo].[Customer] ([customer_id], [customer_name], [state], [phone], [note]) VALUES (2, N'David Moyes', N'HCM', N'0932454567', N'KHTN')
INSERT [dbo].[Customer] ([customer_id], [customer_name], [state], [phone], [note]) VALUES (3, N'Đỗ Trọng Anh Tuấn', N'Hải Phòng', N'0917463234', N'none')
INSERT [dbo].[Customer] ([customer_id], [customer_name], [state], [phone], [note]) VALUES (4, N'Nguyễn Mạnh Hoàng', N'Hà Nội', N'0989786743', N'none')
INSERT [dbo].[Customer] ([customer_id], [customer_name], [state], [phone], [note]) VALUES (5, N'Cristiano Ronaldo', N'Portugal', N'0918233311', N'none')
INSERT [dbo].[Customer] ([customer_id], [customer_name], [state], [phone], [note]) VALUES (6, N'Bá Công Phong', N'Hà Nội', N'0956475865', N'none')
INSERT [dbo].[Customer] ([customer_id], [customer_name], [state], [phone], [note]) VALUES (7, N'Nguyễn Mạnh Kiên', N'Đà Nẵng', N'0943526112', N'KHTN')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
INSERT [dbo].[Detail_ExportBill] ([export_id], [product_id], [quantity], [total_price], [discount]) VALUES (1, 1, 2, 1500, 300)
INSERT [dbo].[Detail_ExportBill] ([export_id], [product_id], [quantity], [total_price], [discount]) VALUES (1, 2, 2, 1350, 0)
INSERT [dbo].[Detail_ExportBill] ([export_id], [product_id], [quantity], [total_price], [discount]) VALUES (1, 3, 1, 3000, 0)
INSERT [dbo].[Detail_ExportBill] ([export_id], [product_id], [quantity], [total_price], [discount]) VALUES (2, 4, 1, 9000, 0)
INSERT [dbo].[Detail_ExportBill] ([export_id], [product_id], [quantity], [total_price], [discount]) VALUES (2, 5, 1, 900, 180)
INSERT [dbo].[Detail_ExportBill] ([export_id], [product_id], [quantity], [total_price], [discount]) VALUES (2, 6, 1, 6000, 0)
INSERT [dbo].[Detail_ExportBill] ([export_id], [product_id], [quantity], [total_price], [discount]) VALUES (2, 11, 4, 9000, 7200)
INSERT [dbo].[Detail_ExportBill] ([export_id], [product_id], [quantity], [total_price], [discount]) VALUES (2, 12, 1, 900, 0)
INSERT [dbo].[Detail_ExportBill] ([export_id], [product_id], [quantity], [total_price], [discount]) VALUES (3, 9, 4, 8000, 0)
INSERT [dbo].[Detail_ExportBill] ([export_id], [product_id], [quantity], [total_price], [discount]) VALUES (3, 10, 2, 3000, 0)
INSERT [dbo].[Detail_ExportBill] ([export_id], [product_id], [quantity], [total_price], [discount]) VALUES (4, 6, 3, 6000, 3600)
INSERT [dbo].[Detail_ExportBill] ([export_id], [product_id], [quantity], [total_price], [discount]) VALUES (4, 7, 4, 3500, 0)
INSERT [dbo].[Detail_ExportBill] ([export_id], [product_id], [quantity], [total_price], [discount]) VALUES (4, 8, 1, 10000, 5000)
INSERT [dbo].[Detail_ExportBill] ([export_id], [product_id], [quantity], [total_price], [discount]) VALUES (5, 1, 1, 1500, 0)
INSERT [dbo].[Detail_ExportBill] ([export_id], [product_id], [quantity], [total_price], [discount]) VALUES (5, 2, 1, 1350, 270)
INSERT [dbo].[Detail_ExportBill] ([export_id], [product_id], [quantity], [total_price], [discount]) VALUES (5, 3, 4, 3000, 0)
INSERT [dbo].[Detail_ExportBill] ([export_id], [product_id], [quantity], [total_price], [discount]) VALUES (5, 4, 1, 9000, 0)
INSERT [dbo].[Detail_ExportBill] ([export_id], [product_id], [quantity], [total_price], [discount]) VALUES (5, 6, 1, 6000, 0)
INSERT [dbo].[Detail_ExportBill] ([export_id], [product_id], [quantity], [total_price], [discount]) VALUES (5, 8, 1, 10000, 2000)
INSERT [dbo].[Detail_ExportBill] ([export_id], [product_id], [quantity], [total_price], [discount]) VALUES (6, 4, 5, 9000, 13500)
INSERT [dbo].[Detail_ExportBill] ([export_id], [product_id], [quantity], [total_price], [discount]) VALUES (7, 5, 3, 900, 0)
GO
INSERT [dbo].[Detail_ImportBill] ([import_id], [product_id], [quantity], [priceAitem], [total_price]) VALUES (2, 1, 15, 200, 3000)
INSERT [dbo].[Detail_ImportBill] ([import_id], [product_id], [quantity], [priceAitem], [total_price]) VALUES (3, 2, 14, 300, 4200)
GO
SET IDENTITY_INSERT [dbo].[ExportBill] ON 

INSERT [dbo].[ExportBill] ([id], [export_date], [staff_id], [customer_id], [total_price], [note]) VALUES (1, CAST(N'2020-03-25T16:09:23.933' AS DateTime), N'admin', 1, 8400, N'None')
INSERT [dbo].[ExportBill] ([id], [export_date], [staff_id], [customer_id], [total_price], [note]) VALUES (2, CAST(N'2020-03-25T16:09:51.677' AS DateTime), N'yasuo', 2, 45420, N'None')
INSERT [dbo].[ExportBill] ([id], [export_date], [staff_id], [customer_id], [total_price], [note]) VALUES (3, CAST(N'2020-03-25T16:10:04.027' AS DateTime), N'viet', 4, 38000, N'None')
INSERT [dbo].[ExportBill] ([id], [export_date], [staff_id], [customer_id], [total_price], [note]) VALUES (4, CAST(N'2020-03-25T16:10:14.470' AS DateTime), N'kien', 5, 33400, N'None')
INSERT [dbo].[ExportBill] ([id], [export_date], [staff_id], [customer_id], [total_price], [note]) VALUES (5, CAST(N'2020-03-25T16:10:24.097' AS DateTime), N'phong', 6, 37580, N'None')
INSERT [dbo].[ExportBill] ([id], [export_date], [staff_id], [customer_id], [total_price], [note]) VALUES (6, CAST(N'2020-03-25T16:10:30.360' AS DateTime), N'tuan', 7, 31500, N'None')
INSERT [dbo].[ExportBill] ([id], [export_date], [staff_id], [customer_id], [total_price], [note]) VALUES (7, CAST(N'2020-03-25T16:11:01.890' AS DateTime), N'staff', 3, 2700, N'None')
SET IDENTITY_INSERT [dbo].[ExportBill] OFF
GO
SET IDENTITY_INSERT [dbo].[ImportBill] ON 

INSERT [dbo].[ImportBill] ([id], [import_date], [staff_id], [suplier_id], [total_price]) VALUES (2, CAST(N'2019-03-03T00:00:00.000' AS DateTime), N'admin', 2, 4000)
INSERT [dbo].[ImportBill] ([id], [import_date], [staff_id], [suplier_id], [total_price]) VALUES (3, CAST(N'2019-04-05T00:00:00.000' AS DateTime), N'staff', 1, 6000)
SET IDENTITY_INSERT [dbo].[ImportBill] OFF
GO
SET IDENTITY_INSERT [dbo].[orderDetais] ON 

INSERT [dbo].[orderDetais] ([id], [order_id], [sanpham_id], [soluong], [tongtien]) VALUES (1, 1, 25, 1, 1500)
INSERT [dbo].[orderDetais] ([id], [order_id], [sanpham_id], [soluong], [tongtien]) VALUES (2, 1, 23, 1, 9000)
INSERT [dbo].[orderDetais] ([id], [order_id], [sanpham_id], [soluong], [tongtien]) VALUES (3, 2, 3, 1, 3000)
INSERT [dbo].[orderDetais] ([id], [order_id], [sanpham_id], [soluong], [tongtien]) VALUES (4, 2, 22, 1, 9000)
SET IDENTITY_INSERT [dbo].[orderDetais] OFF
GO
SET IDENTITY_INSERT [dbo].[orders] ON 

INSERT [dbo].[orders] ([id], [ten], [statuc], [ngaytao], [users_id]) VALUES (1, N'Don hang - 20240523112424', 1, CAST(N'2024-05-23T11:24:24.527' AS DateTime), N'admin1')
INSERT [dbo].[orders] ([id], [ten], [statuc], [ngaytao], [users_id]) VALUES (2, N'Don hang - 20240523201627', 1, CAST(N'2024-05-23T20:16:27.830' AS DateTime), N'admin1')
SET IDENTITY_INSERT [dbo].[orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (1, N'Táo mỹ ', 1200, 1500, 35, 1, N'https://img1.kienthucvui.vn/uploads/2019/10/30/hinh-anh-rau-cu-qua-dep-nhat_112153376.jpg', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (2, N'Kiwi Úc', 1100, 1350, 45, 5, N'https://bloganchoi.com/wp-content/uploads/2021/03/rau-cu.jpg', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (3, N'Nho Ninh Thuận', 2500, 3000, 40, 1, N'http://dalatcenter.com.vn/images/noi-dung/tang-1/rau-cu-qua-da-lat/RauCuHoaTrai1.jpg', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (4, N'Vải Bắc Giang', 5000, 9000, 20, 3, N'https://img1.kienthucvui.vn/uploads/2019/10/30/hinh-anh-rau-cu-qua-sach_112153720.jpg', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (5, N'Chôm chôm java', 500, 900, 25, 5, N'https://bpackingapp.com/wp-content/uploads/2021/12/hinh-anh-rau-cu-qua-ngon_112153517-780x470.jpg', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (6, N'Mãng cầu Tây Ninh', 5000, 6000, 40, 1, N'https://img1.kienthucvui.vn/uploads/2019/10/30/anh-dep-ve-rau-cu_112150641.jpg', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (7, N'Xoài đồng tháp', 2000, 3500, 36, 4, N'https://camnang24h.net/wp-content/uploads/2021/06/hinh-nen-rau-cu-qua-cho-may-tinh-1.jpg', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (8, N'Cam sành Hà Giang', 6000, 10000, 55, 1, N'https://img1.kienthucvui.vn/uploads/2019/10/30/anh-rau-cu-qua-dep-nhat_112150813.jpg', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (9, N'Bưởi Năm Roi', 3000, 8000, 40, 6, N'https://img1.kienthucvui.vn/uploads/2019/10/30/hinh-anh-rau-cu_112154579.jpg', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (10, N'Bưởi da xanh', 2500, 3000, 40, 1, N'https://i.pinimg.com/originals/6e/fb/ec/6efbec49a0a150e42903f894544e4649.jpg', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (11, N'Măng cụt', 5000, 9000, 20, 3, N'https://i.pinimg.com/originals/6e/fb/ec/6efbec49a0a150e42903f894544e4649.jpg', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (12, N'Xoài đỏ', 500, 900, 25, 5, N'https://mayxaygiadinh.com/Systems/2021/07/09/rau-cu-qua-tuoi-1.jpg', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (13, N'Mận Sơn La', 1200, 1500, 35, 1, N'https://img1.kienthucvui.vn/uploads/2019/10/30/hinh-anh-rau-cu-dep_112152829.jpg', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (14, N'Sầu riêng', 1100, 1350, 45, 5, N'https://anhdep123.com/wp-content/uploads/2020/11/hinh-anh-rau-cu-dep.jpg', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (15, N'Mít tố nữ', 2500, 3000, 40, 1, N'https://img1.kienthucvui.vn/uploads/2019/10/30/anh-rau-cu-qua-cuc-dep_112150766.jpeg', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (16, N'Vũ sữa hoàng kim', 6000, 10000, 55, 1, N'https://thucphamdongxanh.com/wp-content/uploads/2019/10/tim-nha-cung-cap-rau-cu-qua-tuoi-ngon.jpg', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (17, N'Ổi bố hạ', 3000, 8000, 40, 6, N'https://thucphamdongxanh.com/wp-content/uploads/2019/12/chon-rau-cu-qua-sach-tam-quan-trong.jpeg', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (18, N'Ổi đào Hải Dương', 2500, 3000, 40, 1, N'https://img1.kienthucvui.vn/uploads/2019/10/30/hinh-anh-rau-cu-qua-trung-bay_112154360.jpg', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (19, N'Cam đường canh', 1200, 1500, 35, 1, N'https://tse3.mm.bing.net/th?id=OIP.Ye7J9O0LAmb23H65BreMuwHaD8&pid=Api&P=0&h=180', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (20, N'Cam cao phong', 1100, 1350, 45, 5, N'https://img1.kienthucvui.vn/uploads/2019/10/30/hinh-anh-ve-cac-loai-rau-cu-qua_112154673.jpg', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (21, N'Cam vinh', 2500, 3000, 40, 1, N'https://redpineinternational.vn/wp-content/uploads/2020/03/image1.jpg', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (22, N'Bưởi đỏ', 5000, 9000, 20, 3, N'https://tienganhabc.net/wp-content/uploads/2021/03/tu-vung-tieng-anh-rau-cu-qua-1024x682.jpg', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (23, N'Bưởi diễn', 5000, 9000, 20, 3, N'https://img1.kienthucvui.vn/uploads/2019/10/30/hinh-anh-rau-cu-qua-dep_112153407.jpg', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (24, N'Táo đài loan', 500, 900, 25, 5, N'https://anhdep123.com/wp-content/uploads/2020/11/hinh-anh-ve-cac-loai-rau-cu-qua.jpg', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (25, N'Roi đỏ', 1200, 1500, 35, 1, N'https://img1.kienthucvui.vn/uploads/2019/10/30/hinh-anh-khay-rau-cu-qua_112152579.jpg', 1)
INSERT [dbo].[Product] ([product_id], [product_name], [price_import], [price_sale], [quantity], [category_id], [image], [status_id]) VALUES (26, N'Dưa hấu Sài Gòn', 1100, 1350, 45, 5, N'https://khostock.net/wp-content/uploads/2019/10/10-trieu-hinh-anh-rau-cu-000-600x440.jpg', 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
INSERT [dbo].[Staff] ([staff_id], [staff_name], [dateOfBirth], [gender], [address], [note]) VALUES (N'viet', N'Khắc Việt', CAST(N'1999-12-20' AS Date), N'male', N'Hà Nội', N'none')
INSERT [dbo].[Staff] ([staff_id], [staff_name], [dateOfBirth], [gender], [address], [note]) VALUES (N'tuan', N'Anh Tuấn', CAST(N'1999-03-03' AS Date), N'female', N'HCM', N'none')
INSERT [dbo].[Staff] ([staff_id], [staff_name], [dateOfBirth], [gender], [address], [note]) VALUES (N'kien', N'Mạnh Kiên', CAST(N'1999-09-09' AS Date), N'male', N'Đà Nẵng', N'none')
INSERT [dbo].[Staff] ([staff_id], [staff_name], [dateOfBirth], [gender], [address], [note]) VALUES (N'phong', N'Công Phong', CAST(N'1999-04-12' AS Date), N'male', N'HCM', N'none')
INSERT [dbo].[Staff] ([staff_id], [staff_name], [dateOfBirth], [gender], [address], [note]) VALUES (N'hoang', N'Mạnh Hoàng', CAST(N'1999-10-11' AS Date), N'male', N'Hà Nội', N'none')
INSERT [dbo].[Staff] ([staff_id], [staff_name], [dateOfBirth], [gender], [address], [note]) VALUES (N'yasuo', N'Yasuo', CAST(N'2005-09-09' AS Date), N'male', N'Hải Phòng', N'none')
INSERT [dbo].[Staff] ([staff_id], [staff_name], [dateOfBirth], [gender], [address], [note]) VALUES (N'staff', N'Teemo', CAST(N'2006-09-12' AS Date), N'female', N'HCM', N'none')
INSERT [dbo].[Staff] ([staff_id], [staff_name], [dateOfBirth], [gender], [address], [note]) VALUES (N'admin', N'Admintrator', CAST(N'1999-09-11' AS Date), N'male', N'HCM', N'none')
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([status_id], [status_name]) VALUES (1, N'Còn hàng')
INSERT [dbo].[Status] ([status_id], [status_name]) VALUES (2, N'Hết Hàng')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Suplier] ON 

INSERT [dbo].[Suplier] ([suplier_id], [suplier_name], [address], [phone]) VALUES (1, N'Nam', N'Cà Mau', N'0957485133')
INSERT [dbo].[Suplier] ([suplier_id], [suplier_name], [address], [phone]) VALUES (2, N'Cường', N'HCM', N'0938432123')
INSERT [dbo].[Suplier] ([suplier_id], [suplier_name], [address], [phone]) VALUES (3, N'Mạnh', N'Hà Nội', N'0999963111')
INSERT [dbo].[Suplier] ([suplier_id], [suplier_name], [address], [phone]) VALUES (4, N'Hải', N'HCM', N'0917333211')
INSERT [dbo].[Suplier] ([suplier_id], [suplier_name], [address], [phone]) VALUES (5, N'Linh', N'HCM', N'0192734312')
SET IDENTITY_INSERT [dbo].[Suplier] OFF
GO
ALTER TABLE [dbo].[Detail_ExportBill]  WITH CHECK ADD  CONSTRAINT [FK_Detail_ExportBill_ExportBill] FOREIGN KEY([export_id])
REFERENCES [dbo].[ExportBill] ([id])
GO
ALTER TABLE [dbo].[Detail_ExportBill] CHECK CONSTRAINT [FK_Detail_ExportBill_ExportBill]
GO
ALTER TABLE [dbo].[Detail_ExportBill]  WITH CHECK ADD  CONSTRAINT [FK_Detail_ExportBill_Product] FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([product_id])
GO
ALTER TABLE [dbo].[Detail_ExportBill] CHECK CONSTRAINT [FK_Detail_ExportBill_Product]
GO
ALTER TABLE [dbo].[Detail_ImportBill]  WITH CHECK ADD  CONSTRAINT [FK_Detail_ImportBill_ImportBill] FOREIGN KEY([import_id])
REFERENCES [dbo].[ImportBill] ([id])
GO
ALTER TABLE [dbo].[Detail_ImportBill] CHECK CONSTRAINT [FK_Detail_ImportBill_ImportBill]
GO
ALTER TABLE [dbo].[Detail_ImportBill]  WITH CHECK ADD  CONSTRAINT [FK_Detail_ImportBill_Product] FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([product_id])
GO
ALTER TABLE [dbo].[Detail_ImportBill] CHECK CONSTRAINT [FK_Detail_ImportBill_Product]
GO
ALTER TABLE [dbo].[ExportBill]  WITH CHECK ADD  CONSTRAINT [FK_ExportBill_Account] FOREIGN KEY([staff_id])
REFERENCES [dbo].[Account] ([username])
GO
ALTER TABLE [dbo].[ExportBill] CHECK CONSTRAINT [FK_ExportBill_Account]
GO
ALTER TABLE [dbo].[ExportBill]  WITH CHECK ADD  CONSTRAINT [FK_ExportBill_Customer] FOREIGN KEY([customer_id])
REFERENCES [dbo].[Customer] ([customer_id])
GO
ALTER TABLE [dbo].[ExportBill] CHECK CONSTRAINT [FK_ExportBill_Customer]
GO
ALTER TABLE [dbo].[ImportBill]  WITH CHECK ADD  CONSTRAINT [FK_ImportBill_Account] FOREIGN KEY([staff_id])
REFERENCES [dbo].[Account] ([username])
GO
ALTER TABLE [dbo].[ImportBill] CHECK CONSTRAINT [FK_ImportBill_Account]
GO
ALTER TABLE [dbo].[ImportBill]  WITH CHECK ADD  CONSTRAINT [FK_ImportBill_Suplier] FOREIGN KEY([suplier_id])
REFERENCES [dbo].[Suplier] ([suplier_id])
GO
ALTER TABLE [dbo].[ImportBill] CHECK CONSTRAINT [FK_ImportBill_Suplier]
GO
ALTER TABLE [dbo].[orderDetais]  WITH CHECK ADD FOREIGN KEY([order_id])
REFERENCES [dbo].[orders] ([id])
GO
ALTER TABLE [dbo].[orderDetais]  WITH CHECK ADD  CONSTRAINT [FK__orderDeta__sanph__3D5E1FD2] FOREIGN KEY([sanpham_id])
REFERENCES [dbo].[Product] ([product_id])
GO
ALTER TABLE [dbo].[orderDetais] CHECK CONSTRAINT [FK__orderDeta__sanph__3D5E1FD2]
GO
ALTER TABLE [dbo].[orders]  WITH CHECK ADD FOREIGN KEY([users_id])
REFERENCES [dbo].[Account] ([username])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([category_id])
REFERENCES [dbo].[Category] ([cate_id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Status] FOREIGN KEY([status_id])
REFERENCES [dbo].[Status] ([status_id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Status]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Account] FOREIGN KEY([staff_id])
REFERENCES [dbo].[Account] ([username])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Account]
GO
