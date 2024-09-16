create table test.clients
(
    id                 bigserial not null,
    form_id            bigint    not null,
    front_side_file_id bigint    not null,
    back_side_file_id  bigint    not null,

    constraint "fk_clients" primary key (id)
);

insert into test.clients(form_id, front_side_file_id, back_side_file_id)
values (1, 1, 1),
       (2, 2, 2);

create table test.form_history
(
    id               bigserial    not null,
    form_id          bigint       not null,
    update_date_time timestamp    not null,
    name             varchar(255) not null,
    surname          varchar(255) null,
    front_side_path  varchar(255) null,
    back_side_path   varchar(255) null,

    constraint pk_forms primary key (id)
);

insert into test.form_history(form_id, update_date_time, name, surname, front_side_path, back_side_path)
values (1, '2023-12-01 00:00:00.000000', '1Name1', '1Surname1', 'name1-front-side-1', 'name1-back-side-1'),
       (1, '2023-12-03 00:00:00.000000', '1Name2', '1Surname1', 'name1-front-side-3', 'name1-back-side-2'),
       (1, '2023-12-05 00:00:00.000000', '1Name2', '1Surname2', 'name1-front-side-4', 'name1-back-side-4'),
       (1, '2023-12-07 00:00:00.000000', '1Name3', '1Surname3', 'name1-front-side-6', 'name1-back-side-6'),

       (2, '2023-12-01 00:00:00.000000', '2Name1', '2Surname1', 'name2-front-side-1', 'name2-back-side-1'),
       (2, '2023-12-03 00:00:00.000000', '2Name2', '2Surname1', 'name2-front-side-3', 'name2-back-side-2'),
       (2, '2023-12-05 00:00:00.000000', '2Name2', '2Surname2', 'name2-front-side-4', 'name2-back-side-4'),
       (2, '2023-12-07 00:00:00.000000', '2Name3', '2Surname3', 'name2-front-side-6', 'name2-back-side-6');

create table test.front_side_files_history
(
    id               bigserial    not null,
    file_id          bigint       not null,
    update_date_time timestamp    not null,
    path             varchar(255) null,

    constraint pk_front_side_files_history primary key (id)
);

create table test.back_side_files_history
(
    id               bigserial    not null,
    file_id          bigint       not null,
    update_date_time timestamp    not null,
    path             varchar(255) null,

    constraint pk_back_side_files_history primary key (id)
);

insert into test.front_side_files_history(file_id, update_date_time, path)
values (1, '2023-12-02 00:00:00.000000', 'name-1-front-side-2'),
       (1, '2023-12-06 00:00:00.000000', 'name-1-front-side-5'),
       (2, '2023-12-02 00:00:00.000000', 'name-2-front-side-2'),
       (2, '2023-12-06 00:00:00.000000', 'name-2-front-side-5');

insert into test.back_side_files_history(file_id, update_date_time, path)
values (1, '2023-12-02 00:00:00.000000', 'name-1-back-side-3'),
       (1, '2023-12-06 00:00:00.000000', 'name-1-back-side-5'),
       (2, '2023-12-02 00:00:00.000000', 'name-2-back-side-3'),
       (2, '2023-12-06 00:00:00.000000', 'name-2-back-side-5');

--insert into test.form_history (form_id, update_date_time, name, surname, front_side_path, back_side_path)

select distinct fh.form_id,
       fsf.update_date_time,
       lag(fh.name) over w,
       lag(fh.surname) over w,
       fsf.path,
       null as back_side_file_path
from test.front_side_files_history fsf
left join test.clients c on c.front_side_file_id = fsf.file_id
left join test.form_history fh on fh.form_id = c.form_id
window w as (partition by fh.form_id order by fh.update_date_time);

select distinct fh.form_id,
       fsf.update_date_time,
       lag(fh.name) over w,
       lag(fh.surname) over w,
       fsf.path,
       null as back_side_file_path
from test.front_side_files_history fsf
left join test.clients c on c.front_side_file_id = fsf.file_id
left join test.form_history fh on fh.form_id = c.form_id
window w as (partition by fh.form_id order by fh.update_date_time);



select distinct
    fh.form_id,
       fsf.update_date_time,
       fh.name,
       fh.surname,
       fsf.path,
       null as back_side_file_path
from test.front_side_files_history fsf
left join test.clients c on c.front_side_file_id = fsf.file_id
left join test.form_history fh on fh.form_id = c.form_id;


select * from test.front_side_files_history fsfh
left join test.clients c on c.front_side_file_id = fsfh.file_id;