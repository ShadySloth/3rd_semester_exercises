
### Guided solutions can be found here: https://github.com/uldahlalex/dotnetwebapi check Controllers/SolutionsController.cs

### Intro: Read this to know what it's about.
We need to make a .NET Web API, because we need to be able to send data over the web. This application should function as the backend server, so client applications can send HTTP requests and get data back.


### Create and Run a Web API

- **Task:** Create a new Web API. Preferably one with Controllers.
Using Rider: pick New Solution (press double shift to search for this). Then select ASP.NET Core Webapplication. Under type, select the Model-View-Controller API.
Alternatively, you can use the .NET CLI. For newer version, write dotnet new webapi --help and look for the flag to distinguish between minimal API or Controllers.
- **Success Criteria:** You should be able to see a new .NET project. Start it using dotnet run, and check in the console, that it starts. 

**Objective:** You must know how to set up a basic Web API with a single endpoint.

---

### Swagger / OpenAPI



- **Task:** When the program is running, try and open the Swagger / OpenAPI page, and request an endpoint.
If Swagger is not enabled in Program.cs, see this guide: 
https://learn.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-8.0&tabs=visual-studio

- **Success Criteria:** Getting an HTTP response from the default startup application through Swagger.

**Objective:** Learn to navigate to Swagger and send basic requests.

---

### New Controller with controller method



- **Task:** Create a new Controller class. Use the following syntax:

```c#
[ApiController]
public class MyNewController : ControllerBase {}
```
Now make a controller method in here. Add a route and HTTP type like this:

```c#
[HttpGet]
[Route("/example")]
public object ExampleMethodName() {
    return "hello from the web server";
}
```

Now run the application, and send a request to your localhost webserver (see port number in the console). Don't forget to add /example, or simply use Swagger.

- **Success Criteria:** You should be able to discover the endpoint in Swagger and send request and get a response.

**Objective:** Learn to make a new controller method and request this.

---

### Two methods in one controller



**Task:** Add another method with a different route than the first one. Make it return a different string than the first one.

**Success Criteria:** You should be able to access both controller methods by sending requests to different routes.

**Learning Objective:** You should notice that the server can respond with different content depending on the request route.


---

### GET entity/{id}

**Task:** A client wants to request some particular piece of data (like something to be looked up in a database by ID).

Read this section about parameter binding: https://www.dotnettricks.com/learn/webapi/model-binding-model-binder-example

Now use The [FromRoute] attribute to bind an ID in a url such as 
http://localhost:5000/entity/123
```C#
public object MyMethodName([FromRoute] int id) { }
```

Return the ID to the requester to check you successfully can read the ID from the route.

**Success criteria:** When inserting id 42 in Swagger as route segment, you should be able to get the id number response


**Learning objective:** You must know how to read/get data from a route segment which the client passes

---

### GET entity?someKey=someValue

**Task:** Make a GET endpoint that can read a query parameter using:

```c#
[FromQuery]string someValue
```
Return the value to the client.

**Success criteria:** When inserting hello world as a query parameter, you should get that value returned.

**Learning objective:** You must know how to read/get data from a query parameter which the client passes

---

### Setting some response header with HttpContext

#### Note: You can both read/write the headers using this class:

**Task:** Use the HttpContext class to set some HTTP response header in some endpoint.

**Success criteria:** Send a request to that endpoint with Postman and inspect the response headers. The value should be present.

**Learning objective:** You must know how to use the HttpContext to modify http responses.

---

### Response JSON

**Task:** Return some JSON object to the client in the body(payload) by returning a C# object in your controller method.

**Success criteria**: If the serialization is successful, the client should get the object values as JSON.

**Learning objective**: You must know how to set the HTTP response body.

---

### Response status code

**Task:** Manually set the response status code. You can do this using HttpContext.Response.StatusCode. Pick an obscure status code like 418, so you don't accidentally pick the same code as the default.

**Success criteria**: You should see the expected code client side.

**Learning objective**: You must know how to indicate the response status to the client by using status codes.

---


