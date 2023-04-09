USE [T_PLUS]
GO

/****** Object:  Table [dbo].[HouseConsumptions]    Script Date: 09.04.2023 21:57:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[HouseConsumptions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateCreate] [datetime2](7) NOT NULL,
	[Weather] [float] NOT NULL,
	[Consumption] [float] NOT NULL,
	[HouseConsumerId] [int] NOT NULL,
 CONSTRAINT [PK_HouseConsumptions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[HouseConsumptions]  WITH CHECK ADD  CONSTRAINT [FK_HouseConsumptions_Houses_HouseConsumerId] FOREIGN KEY([HouseConsumerId])
REFERENCES [dbo].[Houses] ([ConsumerId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[HouseConsumptions] CHECK CONSTRAINT [FK_HouseConsumptions_Houses_HouseConsumerId]
GO

