--liquibase formatted sql

--changeset dpaklin:10
create table test.clients
(
    id    bigserial    not null,
    value varchar(255) null,

    constraint pk_clients primary key (id)
);
--rollback drop table test.clients;

--changeset dpaklin:20
create table test.wallets
(
    id        bigserial    not null,
    client_id bigint       not null,
    value     varchar(255) null,

    constraint pk_wallet primary key (id),

    constraint "fk_wallet#client" foreign key (client_id)
        references test.clients (id)
);
--rollback drop table test.wallets;

--changeset dpaklin:30
insert into test.clients(value)
values (111),
       (222);
--rollback ;

--changeset dpaklin:40
insert into test.wallets(client_id, value)
values (1, 111),
       (2, 222),
       (2, 333);
--rollback ;