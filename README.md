# BW-Melder

This web application aims to replace paper forms used for registering athletes and coaches for the national U15 competition. Their data is instead collected using online forms.

## Setup

Please set the following variables in the appsettings or as environment variables:

Key | Description
----|-------------
AppAdmin.Username | Username for the admin login. Mandatory for production, optional in development with default "appadmin".
AppAdmin.Password | Password for the admin login. Mandatory for production, optional in development with default "password".
Database | Filename for the SQLite database, can be a full path. Optional with default "bwmelder.db" in the app folder.