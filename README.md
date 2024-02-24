# Parks

#### By Jonathan Song

#### API that utilizes CRUD to manage database

## Technologies Used

* C#
* VScode
* Entity Framework Core
* SQL
* ASP.NET

## Description
API that connnects to a SQL database, and accepts requests that creates, reads, updates, and deletes data entries.


## Setup/Installation Requirements

* Navigate to the repository of the named project through this [link](https://github.com/boboflofo/Parks.git)
* Ensure that the .NET SDK is installed to the latest version [link](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* Ensure that MySQL is installed to the latest version [link](https://www.mysql.com/)
* Ensure that MySQL workbench is installed to the latest version [link](https://www.mysql.com/products/workbench/)
* On the top right of the screen, navigate to the **fork** button and fork the repository
* For proper database connection, ensure that a MySQL server is running using command **mysql -u(userid) -p(password)**
* Enter the line below to install and access identity and JWT for authentication with tokens
```
$ dotnet add package Pomelo.EntityFrameworkCore.MySql --version 6.0.0
$ dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 6.0.0
$ dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 6.0.0
```
* Enter the line below to install and access data migrations for database structure
```
$ dotnet tool install --global dotnet-ef --version 6.0.0

$ dotnet add package Microsoft.EntityFrameworkCore.Design -v 6.0.0
```
* To update the sql database using migrations, follow the commands below 
* **note that the first migration should be called Initial** 
```
$ dotnet ef migrations add [Add[variable]To[model]]  

$ dotnet ef database update
```
* Open a code editor such as VScode and in the terminal **git clone** the project for editing capabilities
* Install dependencies for local project under the Parks folder using command **dotnet restore**
* Under the projectname folder, create a **appsettings.json** file and add 
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[YOUR-DB-NAME];uid=[YOUR-USER-HERE];pwd=[YOUR-PASSWORD-HERE];"
  }
}
```
* Under the line above, configure JWT by adding the following code and editing
```
"JWT": {
    "ValidAudience": "example-audience",
    "ValidIssuer": "example-issuer",
    "Secret": "SecretPassword12"
  }

```
* Create a **.gitignore** file and add **obj, bin, and appsettings.json** to ensure personal data is not imported to github
* Finally, run the project using command **dotnet run**

## API endpoints and Authentication with JWT

* Account Controllers and Model are set up with endpoints in which API are made
* Testing endpoints can be used with Postman
* Download the latest version of Postman to test and utilize API calls [link](https://www.postman.com/downloads/)
* Firstly, Authentication with JWT token authentication is primarily used to securely transfer information between users, tokens are here to confirm identity
* With the API set up with authentication, users can register and sign in with unique tokens
* API endpoints for authentication can be sent through POST requests on Postman, for example through this URL `http://localhost:5000/accounts/register` to register an account
* The body of the post request should look like this 
```
{ 
    "email": "jon@test.com",
    "userName": "jon",
    "Password": "Test1234!" 
}

```
* To sign in through a POST request use URL `http://localhost:5000/accounts/signin` with body 

```
{ 
    "email": "jon@test.com",
    "Password": "Test1234!" 
}

```
* Ensure that the token from the signin POST request is inputted into the Auth tab in Postman

* To access data from the NationalPark or StatePark database, a get, post, put, or delete request can be sent through POSTMAN

* EX: `http://localhost:5000/stateparks` is used as an endpoint with a GET request to access all the stateparks 

* EX: `http://localhost:5000/stateparks/1` is used as an endpoint with a GET request to access a specific statepark with body

* EX: `http://localhost:5000/stateparks/` is used as an endpoint with a POST request to add an entry to the stateparks database 

* EX: `http://localhost:5000/stateparks/1` is used as an endpoint with a PUT request to edit an entry to the stateparks database **note the body should contain the specific ID as well**

* EX: `http://localhost:5000/stateparks/1` is used as an endpoint with a DELETE request to delete an entry to the stateparks database


## Known Bugs
n/a

## License
MIT License

Copyright (c) [2023] [Jonathan Song]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.