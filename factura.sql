CREATE DATABASE facturap

use facturap

create table cabezera(
id_cabezera int identity not null primary key,
nombre_cl varchar(100) not null,
cedula varchar(10) not null,
num_factura varchar(10) not null,
base_imp varchar(50),
contacto varchar(10) not null,
correo varchar(100) not null,
precio_tot varchar(50)not null,
)

drop table detalle
drop table cabezera

create table detalle(
id_detalle int identity not null primary key,
cantidad int not null,
iva varchar(50) not null,
precio_unit varchar(50) not null,
producto varchar(300) not null,
id_cabezera int not null,
CONSTRAINT FK_facturacionpersona FOREIGN KEY (id_cabezera)REFERENCES cabezera(id_cabezera)
)

select * from detalle


create type datos_detalles as table(
id int,
cantidad int,
iva varchar(50),
precio_unit varchar(50),
producto varchar(300),
primary key (id)
)

declare @detalleprueba datos_detalles
insert into @detalleprueba(id,cantidad,iva,precio_unit,producto)
values(1,1,0.12,12,'alcohol')
exec dbo.sp_guardarcabezera 'jose','0915471548','1',0.12,'0974587512','jose@gmail.com',@detalleprueba