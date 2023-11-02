@echo off

docker rm playgroundable-db
docker rm playgroundable-minio
docker volume rm playgroundable_postgres-data
docker volume rm playgroundable_minio-data