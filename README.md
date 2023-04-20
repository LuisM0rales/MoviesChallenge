
# MoviesChallenge

Simple project challenge code to validate users with JWT Token, create users, rate movies, CRUD Movies. using C# and .NET 6.0, Also there is another project inside the same solution to use integration Tests for some endpoints of the main project.

The database was created with entityFramework code first and some data is seeded too.
the database was on SQL SERVER.

At PostmanCollection Folder you could found the requests Collections to import at your postman.



## Entity Framework Commands
if there is any change in the database like add new fields or new tables, you must use first this command:

```bash
  Add-Migration <ChagesName>
```

for another way if you has your database already set, you could update database with this command:

```bash
  udpate-database
```

Note: This commands are executed from package manager console at visual studio, in visual studio code the commands are differents.
