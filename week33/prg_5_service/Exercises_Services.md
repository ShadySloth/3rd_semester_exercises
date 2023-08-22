### Exercise: Add a singleton service, and require this

**Task:** 
1. Make a new class called TheDependency, and add this to the builder as a singleton. 
2. Now make another class TheDependent and add this to the builder afterwards. 
3. TheDependent should have a constructor that requires TheDependency. 

**Success criteria:** 
Call a method from TheDependency inside TheDependent to check that you successfully can access your TheDependency singleton service.

**Learning objective:** You must know how to add classes as singleton services to the WebApplicationBuilder and call methods inside this service from other services.

---


### Comparing service lifetimes

**Task**: Make services with different lifetimes (singleton, transient, scoped). These services should log to the console in their constructors *(like: "hello from singleton service X")*. Now require all these services in a controller class, and start sending requests to an endpoint in the controller.

**Success criteria:** You should for instance notice the following:
- The singleton service is constructed once, and never logs the string again, whereas the scoped service is constructed for each request.

**Learning objective**: You should be familiar with the difference between service lifetimes.

---

### Exercise: Set an environment variable

**Task**: Follow my guide in the README.md file to set a system-wide environment variable.

**Success criteria**: When running a .NET application and using Environment.GetEnvironmentVariable(string),
you should be able to log the environment variable to the console (or use for any other purpose).

**Learning objective:** It is vital that any developer knows how to securely set an environment variable, so you don't hardcode environment data straight into the source code. (especially secrets/passwords/etc.)

---

### Exercise: Set an environment variable for your IDE *(often done for unit tests)*

**Task**: Task guide for Rider, go to Settings -> Build, execution, deployment -> Unit testing -> Test runner. Scroll down to environment variables, add an environment variable.
*Remember to .gitignore whatever file your environment variable is being written to*

**Success criteria**: Make an independently executable test, and try to log the environment variable inside of the test. You should get the value just like when using system-wide or terminal emulator environment variables.

**Learning objective:** When running tests, you may use another execution, and therefore require a different environment variable setup.

---

### Exercise: Assess your progress

If you've made it this far, you should be ready for next week, where we're starting to work with Dapper.

I want want to invest more time into sharpening your skills, try to identify one of these areas you want to improve:

- Making SQL queries with PostgreSQL (before starting Dapper on Monday): https://www.w3resource.com/postgresql-exercises/ 
- Sharpening API skills: I suggest adding more features to the CRUD API which you started yesterday (last exercise of yesterday). Here's an outline of a full CRUD you could aim for: 
(Don't bother setting up a database for this exercise. I recommend making a simple in-memory database as an array of objects. Make this array inside of another class (not a controller).

I have made a small CRUD api with GET and POST to show how to get started: https://github.com/uldahlalex/inmemorybasiccrud

This could be a functionality you could try to achieve:
    - GET /entities - This endpoint is used to retrieve a list of entities. The server returns a JSON array of entity objects.

    - GET /entities/{id} - This endpoint retrieves a specific entity by its unique ID. The server returns a JSON object representing the entity if it exists.

    - POST /entities - This endpoint creates a new entity. The client sends a JSON object with the new entity's properties in the body of the request. The server usually returns the newly created entity.

    - PUT /entities/{id} - This endpoint updates an existing entity identified by the unique ID. The client sends a JSON object with the updated properties in the body of the request. The server usually returns the updated entity. If the entity does not exist, the server could either create a new entity or return an error, depending on the API design.

    - PATCH /entities/{id} - This endpoint partially updates an existing entity identified by the unique ID. Unlike PUT, it does not require sending the entire updated entity, only the properties that should be updated. The server usually returns the updated entity.

    - DELETE /entities/{id} - This endpoint deletes an entity by its unique ID. The server usually returns a status indicating whether the deletion was successful.

    - POST /entities/{id}/action - This is an example of how an API can expose specific actions that don't map to the standard CRUD operations. For example, "activate", "deactivate", or "reset" an entity.