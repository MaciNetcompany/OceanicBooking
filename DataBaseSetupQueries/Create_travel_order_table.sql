/****** Object:  Table [dbo].[TravelOrder]    Script Date: 2023-01-12 20:28:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TravelOrder](
	[ID] [uniqueidentifier] NOT NULL,
	[Flights_ID] [uniqueidentifier] NOT NULL,
	[IsBoat] [bit] NOT NULL,
	[IsCar] [bit] NOT NULL,
	[IsPlane] [bit] NOT NULL,
	[ordering_index] [int] NOT NULL,
 CONSTRAINT [PK_TravelOrder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TravelOrder]  WITH CHECK ADD  CONSTRAINT [FK_Flights_TravelOrder] FOREIGN KEY([ID])
REFERENCES [dbo].[Flights] ([ID])
GO

ALTER TABLE [dbo].[TravelOrder] CHECK CONSTRAINT [FK_Flights_TravelOrder]
GO
