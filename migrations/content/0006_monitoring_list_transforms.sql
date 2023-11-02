--liquibase formatted sql

--changeset dpaklin:10
create table test.monitoring_lists
(
    id                    bigint       not null,
    name                  varchar(255) not null,
    persons_count         bigint       not null,
    last_update_date_time timestamp    null,

    constraint pk_monitoring_lists primary key (id)
);
--rollback drop table test.monitoring_lists;

--changeset dpaklin:20
create table test.monitoring_list_transforms
(
    id   bigserial not null,
    xslt varchar   not null,

    constraint pk_monitoring_list_transforms primary key (id)
);
--rollback drop table test.monitoring_list_transforms;

--changeset dpaklin:30
create table test.lists_transforms
(
    monitoring_list_id bigint not null,
    transform_id       bigint not null,

    constraint "fk_monitoring_list_transforms_lists#monitoring_list" foreign key (monitoring_list_id)
        references test.monitoring_lists (id),
    constraint "fk_monitoring_transforms_lists#transform" foreign key (transform_id)
        references test.monitoring_list_transforms (id)
);
--rollback drop table test.transforms_lists;

--changeset dpaklin:40
insert into test.monitoring_lists(id, name, persons_count, last_update_date_time)
values ('1', 'UN', '2000', '2023-10-31 17:25:24.000000'),
       ('2', 'KR', '1000', '2023-10-31 17:25:24.000000'),
       ('3', 'PFT', '500', '2023-10-31 17:25:24.000000'),
       ('4', 'PLPD', '100', '2023-10-31 17:25:24.000000');
