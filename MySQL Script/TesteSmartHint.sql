drop database testesmarthint;
Create Database TesteSmartHint;
use TesteSmartHint;
Create Table Pessoa(
	ID int AUTO_INCREMENT,
    Nome varchar(150) not null,
    Email varchar(150) not null,
    Telefone bigint not null,
    dtCadastro datetime,
    Bloqueado bool,
    InscricaoEstadual bigint,
    Senha varchar(15) not null,
    constraint PK_Pessoa primary key(ID)
);
CREATE TABLE PessoaFisica(
	ID int not null,
    CPF varchar(11),
    Genero varchar(9) not null,
    dtNascimento date not null,
    constraint PK_PessoaFisica primary key (ID),
    constraint FK_Pessoa_PessoaFisica foreign key (ID) references Pessoa(ID) on delete cascade
);
CREATE TABLE PessoaJuridica(
	ID int not null,
    CNPJ varchar(14),
	constraint PK_PessoaJuridica primary key (ID),
    constraint FK_Pessoa_PessoaJuridica foreign key (ID) references Pessoa(ID) on delete cascade
);

insert into Pessoa (Nome, Email, Telefone, dtCadastro, Bloqueado, Senha, InscricaoEstadual) values ('guilherme','gui.brito@gmail.com', 11987366440 ,now(), 0,'testesenha121', 123456789111 );
insert into Pessoa (Nome, Email, Telefone, dtCadastro, Bloqueado, Senha) values ('pedro','pedro.souza@gmail.com',1120457896,now(), 1, 'asd12345789');
insert into Pessoa (Nome, Email, Telefone, dtCadastro, Bloqueado, Senha, InscricaoEstadual) values ('joao','joao.victor@gmail.com',11986325478,now(), 0, 'qweasdzxc',234567847125);
insert into Pessoa (Nome, Email, Telefone, dtCadastro, Bloqueado, Senha, InscricaoEstadual) values ('maria','maria.clara@gmail.com',21978451236,now(), 0, '123/*-4567',534567848125);
insert into Pessoa (Nome, Email, Telefone, dtCadastro, Bloqueado, Senha) values ('teste','teste@gmail.com',50945781269,now(), 0, '147255qsa_');
insert into Pessoa (Nome, Email, Telefone, dtCadastro, Bloqueado, Senha) values ('teste old','testeold@gmail.com',51945781269,'2024-07-18', 0, '147255qsa_');

insert into PessoaFisica (ID, CPF, Genero, dtNascimento) values (1, "43053824825", "Masculino", '1993-07-05');
insert into PessoaFisica (ID, CPF, Genero, dtNascimento) values (4, "62319513086", "Feminino", '2000-12-01');
insert into PessoaFisica (ID, CPF, Genero, dtNascimento) values (5, "68948539086", "Outro", '1998-08-28');

insert into PessoaJuridica (ID, CNPJ) values (2, "09180174000158");
insert into PessoaJuridica (ID, CNPJ) values (3, "51188275000131");
insert into PessoaJuridica (ID, CNPJ) values (1, "32845022000149");


