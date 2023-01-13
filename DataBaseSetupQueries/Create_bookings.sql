/****** Object:  Table [dbo].[Bookings]    Script Date: 2023-01-12 20:26:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Bookings](
	[Id] [uniqueidentifier] NOT NULL,
	[FromCityId] [int] NOT NULL,
	[ToCityId] [int] NOT NULL,
	[Weight] [int] NOT NULL,
	[Height] [int] NOT NULL,
	[Width] [int] NOT NULL,
	[Length] [int] NOT NULL,
	[DeliveryTime] [int] NOT NULL,
	[IsRefrigerated] [bit] NOT NULL,
	[ContainsCautiousGoods] [bit] NOT NULL,
	[ContainsWeapons] [bit] NOT NULL,
	[RequestedAtDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
