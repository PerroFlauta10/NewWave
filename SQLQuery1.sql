CREATE TABLE Producto (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Precio DECIMAL(18, 2) NOT NULL
);

CREATE TABLE Cliente (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Direccion NVARCHAR(200) NOT NULL
);

CREATE TABLE Pedido (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ClienteId INT NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES Cliente(Id)
);

CREATE TABLE PedidoProducto (
    PedidoId INT NOT NULL,
    ProductoId INT NOT NULL,
    FOREIGN KEY (PedidoId) REFERENCES Pedido(Id),
    FOREIGN KEY (ProductoId) REFERENCES Producto(Id),
    PRIMARY KEY (PedidoId, ProductoId)
);

