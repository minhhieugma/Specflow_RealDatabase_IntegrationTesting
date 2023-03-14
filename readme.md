# Welcome to Integration Testing project template using Specflow + Real Database
- A Real Database is created and deleted after each feature/scenario
- Real Database is managed by Docker
- Database seeding is prepared by a *.mdf file and a *.ldf file
- It takes about 25 seconds to create a real database in a 16 GB/i7 laptop

## Use Visual Studio
Just simpli build the project and start test cases in Test Explore

## Use Docker
Manual start a database

```
docker run -d -p 1434:1433 -v .\DatabaseSources\sql-server:C:/temp/ -e sa_password=P@ssw0rd -e attach_dbs="[{'dbName': 'cc3_dev', 'dbFiles': ['C:\\temp\\test_db.mdf', 'C:\\temp\\test_db_log.ldf'] }]" -e ACCEPT_EULA=Y octopusdeploy/mssql-server-windows-express
```