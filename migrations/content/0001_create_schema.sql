--liquibase formatted sql

--changeset dpaklin:10
create schema test;
--rollback drop schema test cascade;