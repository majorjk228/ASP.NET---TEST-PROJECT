USE [T_PLUS]
GO

/****** Object:  Table [dbo].[PlantConsumptions]    Script Date: 09.04.2023 21:58:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlantConsumptions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateCreate] [datetime2](7) NOT NULL,
	[Price] [float] NOT NULL,
	[Consumption] [float] NOT NULL,
	[PlantConsumerId] [int] NOT NULL,
 CONSTRAINT [PK_PlantConsumptions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PlantConsumptions]  WITH CHECK ADD  CONSTRAINT [FK_PlantConsumptions_Plants_PlantConsumerId] FOREIGN KEY([PlantConsumerId])
REFERENCES [dbo].[Plants] ([ConsumerId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[PlantConsumptions] CHECK CONSTRAINT [FK_PlantConsumptions_Plants_PlantConsumerId]
GO

