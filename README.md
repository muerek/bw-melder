# BW-Melder

A simple web application to register athletes and team coaches for the national U15 rowing competition. Team coaches can self-register and coaches can enter their athlete's data online. This web app eliminates a huge pile of paper forms that someone would just have typed into an Excel sheet anyways.

## Setup

Please set the following variables in appsettings.json or as environment variables:

Key | Description
----|-------------
AppAdmin.Username | Username for the admin login. Mandatory for production, optional in development with default `appadmin`.
AppAdmin.Password | Password for the admin login. Mandatory for production, optional in development with default `password`.
Database | Filename for the SQLite database, can be a full path. Optional with default `./bwmelder.db`.
AllowAnonymousRegistration | Flag to enable or disable anonymous access to the registration forms. Optional with default `true`.

## Caveats

"Done is better than perfect" is probably a good way to describe this project. There are certainly better and fancier ways to implement these features, but I chose a pragmatic approach for this project to keep it simple and get it done.

Some notes on design decisions:

- This is a Razor pages web app because the user's internet connection may be unreliable. People will access this web app from their mobile devices somewhere outside a city. With all rendering and data processing server-side in Razor pages, I do not have to deal with timeouts, retries and state management on a client that may go offline every now and then.

- There is no user management for admins because in the anticipated use case, there will be just be one admin logged in. And if there are two, they will be in the same room. 