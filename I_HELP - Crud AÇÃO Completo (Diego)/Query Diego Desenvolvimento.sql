
-- Select em 2 tabelas
select estado.nomest, cidade.nomcid
from estado
inner join cidade on estado.codest = cidade.codest
where codcid=2182;


select * from acao;
update acao set nomeaca='1',codcid=2020, dateini='2021-01-01', datefim='2021-01-01'
where codaca=3;


select * from acao where codcid=4460;
select * from cidade where codcid=4460;