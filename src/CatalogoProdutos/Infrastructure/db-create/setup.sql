CREATE DATABASE CatalogoDeProdutos;
GO

USE CatalogoDeProdutos;
GO

CREATE TABLE Categorias(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nome VARCHAR(200) NOT NULL,
	Descricao VARCHAR(500),
	DataCriacao DATETIME2 NOT NULL DEFAULT GETUTCDATE()
);

CREATE TABLE Produtos(
	Id  INT PRIMARY KEY IDENTITY(1,1),
	Nome VARCHAR(200) NOT NULL,
	Descricao VARCHAR(500),
	Preco DECIMAL(18,2) NOT NULL CHECK (Preco >= 0),
	CategoriaID INT NOT NULL,
	Ativo BIT NOT NULL DEFAULT 1,
	DataCriacao DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	FOREIGN KEY (CategoriaID) REFERENCES Categorias(Id)
);




INSERT INTO Categorias (Nome, Descricao) VALUES
('Eletrônicos', 'Dispositivos que utilizam circuitos e componentes eletrônicos para processar informações. Inclui smartphones, computadores e gadgets inteligentes.'),
('Ferramentas', 'Instrumentos manuais ou elétricos projetados para facilitar tarefas mecânicas, aumentando a eficiência e reduzindo esforço físico.'),
('Casa e Decoração', 'Tudo o que é necessário para transformar ambientes e trazer mais conforto ao lar. Inclui mobiliário, iluminação e objetos decorativos.'),
('Moda e Acessórios', 'Uma seleção completa de vestuário, calçados e complementos para diferentes estilos e ocasiões.'),
('Saúde e Bem-Estar', 'Dedicada ao cuidado pessoal e manutenção de uma vida saudável. Abrange higiene, suplementos e equipamentos fitness.'),
('Alimentos e Bebidas', 'Itens de consumo diário, desde produtos básicos de despensa até seleções gourmet e bebidas variadas.'),
('Ferramentas e Construção', 'Equipamentos e materiais essenciais para reparos domésticos, manutenção ou grandes reformas.'),
('Lazer e Entretenimento', 'Produtos destinados ao tempo livre, hobbies e diversão em família.');




INSERT INTO Produtos (Nome, Descricao, Preco, CategoriaID) VALUES
-- Eletrônicos (ID 1)
('Smartphone X1', 'Tela 6.5 polegadas, 128GB', 1999.00, 1),
('Notebook Pro', 'Processador i7, 16GB RAM', 4500.00, 1),
('Fone Bluetooth', 'Cancelamento de ruído ativo', 250.00, 1),
('Monitor 24pol', 'Full HD 144Hz', 890.00, 1),
('Mouse Gamer', 'RGB com 12000 DPI', 150.00, 1),

-- Ferramentas (ID 2)
('Furadeira Impacto', 'Motor potente 600W', 280.00, 2),
('Jogo de Chaves', 'Kit com 12 peças cromo vanádio', 95.00, 2),
('Trena Laser', 'Medição digital até 40m', 150.00, 2),
('Nível de Bolha', 'Estrutura em alumínio 30cm', 40.00, 2),
('Parafusadeira', 'Bateria 12V Lítio', 220.00, 2),

-- Casa e Decoração (ID 4)
('Luminária de Mesa', 'Design moderno articulado', 85.00, 4),
('Tapete Sala', 'Material sintético 2.0x1.5m', 120.00, 4),
('Vaso de Cerâmica', 'Cor azul marinho fosco', 45.00, 4),
('Quadro Abstrato', 'Moldura em madeira preta', 65.00, 4),
('Almofada Velvet', 'Tecido aveludado cinza', 35.00, 4),

-- Moda e Acessórios (ID 5)
('Camiseta Algodão', 'Tecido premium 100% algodão', 59.90, 5),
('Calça Jeans Slim', 'Corte moderno com elastano', 120.00, 5),
('Tênis Esportivo', 'Amortecimento para corrida', 210.00, 5),
('Relógio de Pulso', 'Analógico em aço inoxidável', 180.00, 5),
('Óculos de Sol', 'Proteção UV400 polarizado', 95.00, 5),

-- Saúde e Bem-Estar (ID 6)
('Tapete de Yoga', 'Antiderrapante 6mm', 80.00, 6),
('Multivitamínico', 'Pote com 60 cápsulas', 45.00, 6),
('Escova Elétrica', 'Limpeza profunda sônica', 130.00, 6),
('Massageador Portátil', 'Alívio de tensões musculares', 110.00, 6),
('Protetor Solar FPS 50', 'Toque seco 50g', 55.00, 6),

-- Alimentos e Bebidas (ID 7)
('Café Especial', 'Grãos torrados 500g', 32.00, 7),
('Azeite Extra Virgem', 'Acidez máxima 0.2%', 42.00, 7),
('Vinho Tinto Reserva', 'Uva Malbec 750ml', 75.00, 7),
('Chocolate Amargo', '70% Cacau orgânico', 18.00, 7),
('Mix de Castanhas', 'Pacote 200g sem sal', 25.00, 7);