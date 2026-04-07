


-----------------PRODUTOS--------------------------------------------------------------------------------


--INSERTS PRODUTOS
INSERT INTO Produtos (Nome,Descricao,Preco,CategoriaID)
VALUES('ESP32','Micro controladora para projetos de automação e IoT', 20.0, 1)

INSERT INTO Produtos (Nome,Descricao,Preco,CategoriaID)
VALUES('Arduino','Micro controladora para projetos simples', 10.0, 1)




--SELECTS PRODUTOS
SELECT * FROM Produtos

--DELETES PRODUTOS
DELETE FROM Produtos 
WHERE Id = 1



--UPDATES PRODUTOS
UPDATE Produtos
SET Nome = 'ArduinoUno',Descricao = 'placa de microcontrolador de código aberto baseada no chip ATmega328P, ideal para iniciantes e prototipagem eletrônica. Possui 14 pinos de entrada/saída digital (6 saídas PWM), 6 entradas analógicas, clock de 16 MHz, e opera com 5V, sendo programado via cabo USB através da Arduino IDE',Preco = 46.5,CategoriaID = 1
WHERE Id = 2


-----------------CATEGORIAS--------------------------------------------------------------------------------

--UPDATES CATEGORIAS
UPDATE Categorias
SET Descricao = 'Instrumentos, manual ou elétrico, projetado para facilitar a execução de tarefas mecânicas, aumentando a eficiência, economizando tempo e reduzindo o esforço físico. Elas são essenciais para fixar, cortar, moldar, medir ou fixar materiais em diversas atividades, desde reparos domésticos até a produção industrial'
WHERE Id = 2





--SELECTS CATEGORIAS
SELECT * FROM Categorias

SELECT * FROM Categorias
WHERE Id = 1



--DELETES CATEGORIAS
DELETE FROM Categorias
WHERE Id = 3





--INSERTS DE CATEGORIAS
INSERT INTO Categorias (Nome, Descricao)
VALUES('Eletrônicos','Dispositivos fabricados que utilizam circuitos, semicondutores e componentes eletrônicos (como transistores e microchips) para controlar, processar ou transmitir energia elétrica e informações. Funcionando tipicamente através de baterias, pilhas ou energia da rede elétrica, esses equipamentos — que incluem smartphones, computadores, televisores e eletrodomésticos inteligentes — têm como finalidade automatizar tarefas, proporcionar entretenimento ou facilitar a comunicação e o acesso à informação')

INSERT INTO Categorias (Nome, Descricao)
VALUES('Ferramentas','é um instrumento, manual ou elétrico, projetado para facilitar a execução de tarefas mecânicas, aumentando a eficiência, economizando tempo e reduzindo o esforço físico. Elas são essenciais para fixar, cortar, moldar, medir ou fixar materiais em diversas atividades, desde reparos domésticos até a produção industrial.')

INSERT INTO Categorias (Nome,Descricao) OUTPUT inserted.*
VALUES('ISCAS DE TILÁPIA','HMMMMMM TILÁPIA, DILISSA')

INSERT INTO Categorias (Nome,Descricao)
VALUES('Casa e Decoração','Tudo o que é necessário para transformar ambientes e trazer mais conforto ao lar. Inclui mobiliário, itens de iluminação, têxteis e objetos decorativos que refletem estilo e funcionalidade em cada cômodo.')

INSERT INTO Categorias (Nome,Descricao)
VALUES('Moda e Acessórios','Uma seleção completa de vestuário, calçados e complementos para diferentes estilos e ocasiões. O foco aqui é unir tendências atuais com peças essenciais para compor o guarda-roupa pessoal.')

INSERT INTO Categorias (Nome,Descricao)
VALUES('Saúde e Bem-Estar','Dedicada ao cuidado pessoal e à manutenção de uma vida saudável. Abrange produtos de higiene, suplementos, itens de cuidados com a pele e equipamentos para atividades físicas moderadas ou intensas.')

INSERT INTO Categorias (Nome,Descricao)
VALUES('Alimentos e Bebidas','Itens de consumo diário, desde produtos básicos de despensa até seleções gourmet e bebidas variadas. Ideal para quem busca praticidade na cozinha ou itens selecionados para momentos especiais.')

INSERT INTO Categorias (Nome,Descricao)
VALUES('Ferramentas e Construção','Equipamentos e materiais essenciais para reparos domésticos, manutenção ou grandes reformas. Focada em durabilidade e precisão, oferece soluções tanto para profissionais quanto para amadores.')

INSERT INTO Categorias (Nome,Descricao)
VALUES('Lazer e Entretenimento','Produtos destinados ao tempo livre, hobbies e diversão em família. Inclui desde jogos e brinquedos até artigos para atividades ao ar livre, garantindo opções de descontração para todas as idades.')
