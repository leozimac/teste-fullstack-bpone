CREATE TABLE if not exists clients(
	id				UUID not null,
	name			VARCHAR(100) not null,
	cpf				VARCHAR(11),
	cnpj			VARCHAR(14),
	active			BOOL,
	creation_date	TIMESTAMP not null,
	update_date		TIMESTAMP,
	deletion_date	TIMESTAMP,
	
	constraint pk_client primary key(id)
);

CREATE table if not exists products(
	id				UUID not null,
	name			VARCHAR(255) not null,
	code			int not null,
	price			decimal(6,2) not null,
	active			bool,
	creation_date	timestamp not null,
	update_date		timestamp,
	deletion_date 	timestamp,
	
	constraint pk_product primary key(id)
);

CREATE TABLE if not exists orders(
	id				UUID not null,
	code			SERIAL,
	creation_date	TIMESTAMP not null,
	client_id		UUID not null,
	
	constraint pk_order primary key(id),
	constraint fk_client_order foreign key (client_id) references clients(id)
);

CREATE table if not exists order_items(
	order_id		UUID not null,
	product_id		UUID not null,
	quantity		int,
	total			decimal(6,2),
	
	constraint pk_order_item primary key (order_id, product_id)
);