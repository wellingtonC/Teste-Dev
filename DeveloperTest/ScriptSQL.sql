create database DBBanco001

use DBBanco001

-- Criação Tabelas
create table Cliente(
	id int IDENTITY(1,1),
	nome varchar(200) not null,
	cpf varchar(11) not null primary key,
	uf varchar(2)not null,
	celular bigint not null
);

create table Financiamento(
	id_financiamento int IDENTITY(1,1) primary key,
	cpf varchar(11) not null,
	tipoFinanciamento varchar(200) not null,
	valorTotal decimal not null,
	dataUltimoVencimento date not null,
);

create table Parcela(
	id_financiamento int,
	numeroParcela int,
	valorParcela decimal,
	dataVencimento datetime,
	dataPagamento datetime
);

-- Alter Table para inserir chave estrangeira
ALTER TABLE financiamento
ADD CONSTRAINT FK_Cpf
FOREIGN KEY (cpf) REFERENCES Cliente(cpf);

ALTER TABLE Parcela
ADD CONSTRAINT FK_idFinanciamento
FOREIGN KEY (id_financiamento) REFERENCES financiamento(id_financiamento);

-- Inserts com valores para popular a tabela
insert into Cliente (nome,cpf,uf,celular) 
	values('Jose Maria', '46678922221', 'SP', 11999909872),('Jose Maria', '46678924444', 'MG', 11999909823),
	('Cleiton Barbosa', '4667893242x', 'SP', 11999909000),('Jhonny Silver', '46678966544', 'SP', 11999909654),
	('Joel Santana', '00823456709', 'SP', 11996759872),('James Joseph', '12823456709', 'SP', 11967598888),
	('Santana Silva', '99823456709', 'SP', 22996759872)

insert into Financiamento(cpf, tipoFinanciamento, valorTotal, dataUltimoVencimento) 
	values('46678922221', 'Credito Consignado', 15000, GETDATE()),('46678922221', 'Credito Consignado', 1000, '2022-10-10'),
		('46678924444', 'Credito Pessoal', 19000, '2023-10-10'),('46678966544', 'Credito Pessoa Juridica',19000,GETDATE()),
		('00823456709', 'Credito Empresarial', 159800, '2023-02-12'),('12823456709', 'Credito Pessoal', 8000000, '2029-12-12'),
		('99823456709', 'Credito Pessoal', 100000, '2032-12-12')

insert into Parcela(id_financiamento,numeroParcela,valorParcela,dataPagamento,dataVencimento) 
	values(1,3,10000,GETDATE(),GETDATE()),(1,2,10000,'2022-08-10','2022-08-10'),(1,1,10000,'2022-07-10','2022-08-10'),
	(2,5,200,GETDATE(),GETDATE()),(3,3,6650,GETDATE(),GETDATE()),(4,10,2000,null,GETDATE()),(5,4,16650,null,'2022-09-09'),
	(6,32,26250,null,'2022-10-09'),(7,40,2625,null,GETDATE())


--Exercicio 1
select * from Cliente as a join Financiamento as b on a.cpf = b.cpf 
		join Parcela as c on c.id_financiamento = b.id_financiamento
		where a.uf like 'SP' and c.valorParcela * c.numeroParcela >= b.valorTotal *0.6

-- Exercicio 2

Select * from Cliente as a join Financiamento as b on a.cpf = b.cpf
		join Parcela as c on b.id_financiamento = c.id_financiamento
		where c.dataVencimento<= GETDATE() and c.dataPagamento is NULL;
