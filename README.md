# HRMS-Website
Human Resource Management System using .NET Core with no API


This is a .NET Core 6.0 project which helps to understand how to do CRUD operations with our build-in database. This web application contains some CRUD functions for Admin, HR, and users.
The Admin user has given all privilages to add user, role, projects etc. The HR user can assign task and project to the common user. The common users can do some CRUD operations


The bak file contains the backup of my database with one admin, one HR user and two users (Ajay and Arun). The credentials for the users are given below.

```sh

Username: admin@gmail.com
Password: Admin@123

Username: hr@gmail.com
Password: Hr@123

Username: ajay@gmail.com
Password: Ajay@123

Username: arun@gmail.com
Password: Arun@123

```

Feel free to use your own database values.

Note: Please change the connection string with your's in application.json file to work perfectly. Also please note that after registering a new user, the admin user must add the details of the new registered user.
