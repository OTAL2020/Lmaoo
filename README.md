## Prerequisite

Ensure that you have installed Docker and Docker Compose, this project can be run both Visual Studio and Visual Studio Code

## Environment File
In the root directory of the folder there is a .env.example file, copy and paste the new file as .env and fill out the information. Developers should use their own ports and credentials, however in the discord server there will be an example filled out for a faster setup.

## How to run the project

Simply clone the repo and change directory to it and run the following command

```bash
docker compose up -d
```
This will spin up the website and the database. Note: You may notice a db_data folder in the root directory, this directory is database mounted data to attain data persistence. DO NOT DELETE THIS.

## How to connect to the database locally
As this is run via Docker, there will be no docker instance name. Using your preferred SQL Server Management, the credentials will be as follows:
```
Server Name: localhost,{db_port}
Username: sa
Password: {db_password}
```
Note: Running the instance SQL Server for the first time, you will need to create a new Lmaoo Database

```sql
CREATE Database Lmaoo;
```