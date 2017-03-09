CREATE TABLE [dbo].[Pratos]
(
	[Id_Prato] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] NCHAR(75) NOT NULL, 
    [Preco] MONEY NOT NULL, 
    [id_Restaurante] INT NOT NULL, 
    CONSTRAINT [FK_Pratos_ToTable] FOREIGN KEY (id_Restaurante) REFERENCES Restaurantes(id_Restaurante) 
)
