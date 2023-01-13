SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Flights](
	[ID] [uniqueidentifier] NOT NULL,
	[order_booking_id] [uniqueidentifier] NOT NULL,
	[origin] [nvarchar](255) NOT NULL,
	[destination] [nvarchar](255) NOT NULL,
	[category] [nvarchar](255) NOT NULL,
	[ParcelWeight] [int] NOT NULL,
	[dimensions] [nvarchar](255) NOT NULL,
	[price] [int] NOT NULL,
	[requestDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Flights] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Flights]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Flights] FOREIGN KEY([ID])
REFERENCES [dbo].[Bookings] ([Id])
GO

ALTER TABLE [dbo].[Flights] CHECK CONSTRAINT [FK_Bookings_Flights]
GO

