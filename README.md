# Dr. Sneuss' Factory
**Weekly Independent Project for Epicodus**  
**By Peter Grimm, 08.07.2020**

## Description

Weekly independent project for Epicodus, an MVC web application to track engineers and the machines they are qualified to service for a factory. Designed to showcase my knowledge and skills with MySQL and the Entity Framework using many-to-many relationships.

## Specifications
User Stories
* As the factory manager, I need to be able to see a list of all engineers, and I need to be able to see a list of all machines.
* As the factory manager, I need to be able to select a engineer, see their details, and see a list of all machines that engineer is licensed to repair. I also need to be able to select a machine, see its details, and see a list of all engineers licensed to repair it.
* As the factory manager, I need to add new engineers to our system when they are hired. I also need to add new machines to our system when they are installed.
* As the factory manager, I should be able to add new machines even if no engineers are employed. I should also be able to add new engineers even if no machines are installed
* As the factory manager, I need to be able to add or remove machines that a specific engineer is licensed to repair. I also need to be able to modify this relationship from the other side, and add or remove engineers from a specific machine.
* I should be able to navigate to a splash page that lists all engineers and machines. Users should be able to click on an individual engineer or machine to see all the engineers/machines that belong to it.

## Setup/Installation Requirements
* .NET Core 2.2 will need to be installed, it can be found here https://dotnet.microsoft.com/download/dotnet-core/2.2
* For Mac users, download MySQL here: https://dev.mysql.com/downloads/file/?id=484914
* For Windows users, download MySQL here: https://dev.mysql.com/downloads/file/?id=484919
* Install MySQL and set the system path, more information on how to do that can be found here: https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql
* Clone the GitHub repository by running `git clone https://github.com/pagrimm/DrSneussFactory.Solution.git` in the terminal
* Navigate to the newly created `DrSneussFactory.Solution` folder
* Navigate to the `DrSneussFactory` subfolder and run `dotnet restore`
* Run `dotnet ef database update` to create the database.
* Run `dotnet build` to build the app and `dotnet run` to run it
* The web app will now be available on `http://localhost:5000/` in your browser

## Technologies Used

C#  
.NET Core 2.2  
ASP.NET Core MVC  
Entity Framework Core 2.2.6 

## Legal

Copyright (c) 2020, Peter Grimm  
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT) This software is licensed under the MIT license.