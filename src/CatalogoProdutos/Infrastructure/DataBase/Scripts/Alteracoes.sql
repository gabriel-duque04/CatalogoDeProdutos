


-----------------PRODUTOS--------------------------------------------------------------------------------


--INSERTS PRODUTOS
INSERT INTO Produtos (Nome,Descricao,Preco,CategoriaID)
VALUES('ESP32','Micro controladora para projetos de automa??o e IoT', 20.0, 1)

INSERT INTO Produtos (Nome,Descricao,Preco,CategoriaID)
VALUES('Arduino','Micro controladora para projetos simples', 10.0, 1)




--SELECTS PRODUTOS
SELECT * FROM Produtos

--DELETES PRODUTOS
DELETE FROM Produtos 
WHERE Id = 1



--UPDATES PRODUTOS
UPDATE Produtos
SET Nome = 'ArduinoUno',Descricao = 'placa de microcontrolador de c?digo aberto baseada no chip ATmega328P, ideal para iniciantes e prototipagem eletr?nica. Possui 14 pinos de entrada/sa?da digital (6 sa?das PWM), 6 entradas anal?gicas, clock de 16 MHz, e opera com 5V, sendo programado via cabo USB atrav?s da Arduino IDE',Preco = 46.5,CategoriaID = 1
WHERE Id = 2


-----------------CATEGORIAS--------------------------------------------------------------------------------

--UPDATES CATEGORIAS
UPDATE Categorias
SET Descricao = 'Instrumentos, manual ou el?trico, projetado para facilitar a execu??o de tarefas mec?nicas, aumentando a efici?ncia, economizando tempo e reduzindo o esfor?o f?sico. Elas s?o essenciais para fixar, cortar, moldar, medir ou fixar materiais em diversas atividades, desde reparos dom?sticos at? a produ??o industrial'
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
VALUES('Eletr?nicos','Dispositivos fabricados que utilizam circuitos, semicondutores e componentes eletr?nicos (como transistores e microchips) para controlar, processar ou transmitir energia el?trica e informa??es. Funcionando tipicamente atrav?s de baterias, pilhas ou energia da rede el?trica, esses equipamentos ? que incluem smartphones, computadores, televisores e eletrodom?sticos inteligentes ? t?m como finalidade automatizar tarefas, proporcionar entretenimento ou facilitar a comunica??o e o acesso ? informa??o')

INSERT INTO Categorias (Nome, Descricao)
VALUES('Ferramentas','? um instrumento, manual ou el?trico, projetado para facilitar a execu??o de tarefas mec?nicas, aumentando a efici?ncia, economizando tempo e reduzindo o esfor?o f?sico. Elas s?o essenciais para fixar, cortar, moldar, medir ou fixar materiais em diversas atividades, desde reparos dom?sticos at? a produ??o industrial.')

INSERT INTO Categorias (Nome,Descricao) OUTPUT inserted.*
VALUES('ISCAS DE TIL?PIA','HMMMMMM TIL?PIA, DILISSA')

INSERT INTO Categorias (Nome,Descricao)
VALUES('Casa e Decora??o','Tudo o que ? necess?rio para transformar ambientes e trazer mais conforto ao lar. Inclui mobili?rio, itens de ilumina??o, t?xteis e objetos decorativos que refletem estilo e funcionalidade em cada c?modo.')

INSERT INTO Categorias (Nome,Descricao)
VALUES('Moda e Acess?rios','Uma sele??o completa de vestu?rio, cal?ados e complementos para diferentes estilos e ocasi?es. O foco aqui ? unir tend?ncias atuais com pe?as essenciais para compor o guarda-roupa pessoal.')

INSERT INTO Categorias (Nome,Descricao)
VALUES('Sa?de e Bem-Estar','Dedicada ao cuidado pessoal e ? manuten??o de uma vida saud?vel. Abrange produtos de higiene, suplementos, itens de cuidados com a pele e equipamentos para atividades f?sicas moderadas ou intensas.')

INSERT INTO Categorias (Nome,Descricao)
VALUES('Alimentos e Bebidas','Itens de consumo di?rio, desde produtos b?sicos de despensa at? sele??es gourmet e bebidas variadas. Ideal para quem busca praticidade na cozinha ou itens selecionados para momentos especiais.')

INSERT INTO Categorias (Nome,Descricao)
VALUES('Ferramentas e Constru??o','Equipamentos e materiais essenciais para reparos dom?sticos, manuten??o ou grandes reformas. Focada em durabilidade e precis?o, oferece solu??es tanto para profissionais quanto para amadores.')

INSERT INTO Categorias (Nome,Descricao)
VALUES('Lazer e Entretenimento','Produtos destinados ao tempo livre, hobbies e divers?o em fam?lia. Inclui desde jogos e brinquedos at? artigos para atividades ao ar livre, garantindo op??es de descontra??o para todas as idades.')
