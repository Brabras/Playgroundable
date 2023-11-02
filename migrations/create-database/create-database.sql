create user playground with password '123';

create database playground_db with owner playground;

\connect playground_db;
create schema liquibase authorization playground;