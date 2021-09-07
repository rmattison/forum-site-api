# Forum Site API

This API is used to access and create forum post data from the Forum Site database.

## Description

By accessing the Web API endpoints, you have the ability to create a post, get one or all posts, update a post, and delete a post. The API connects to the database using a class library named DBAccess. 

### Features

The database connection is created using Dapper and sanitized using parameterised queries.

```csharp
connection.Query<Post>("SELECT * FROM Posts WHERE id = @id", new { id = id });
```
