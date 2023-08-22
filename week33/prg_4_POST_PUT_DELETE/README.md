### Presentation topics:

- Postman HTTP client (limited to building basic HTTP requests with a JSON body)
- POST, PUT & DELETE requests
- More parameter binding
- Making HTTP responses
- Transfer objects
- Response status codes
- The HttpContext in .NET
- Control flow in API's & exceptions
- Data annotations
- The ApiController attribute

**Info**
- Check marketplace (where you install plugins) for Jetbrains AI Assistant
- If you have .NET 8 and want a controller layout without cloning my repo, you can run 

```c#
dotnet new webapi --use-controllers
```

Apparently, Rider with MVC creates a bunch of other stuff, so I recommend the above command.


**Recommended actions:**
- Finish the "FirstWebAPI" from yesterday
- Move on to MoreWebAPI

Slides: https://docs.google.com/presentation/d/e/2PACX-1vRYj1y2DQ-Rfu1uBcxW0TQwnTYz3A8IDFohBitcoWkZ_PIQ7Q4MWMtDM-eA5QZ4eJijbkP-oQWuaUMU/pub?start=false&loop=false&delayms=3000 (I added the command for making controllers layout in .NET 8 for that slide)

### Relevant literature & documentation (high priority in *italics*):
- Download Postman here: https://www.postman.com/downloads/
    - *The Getting started guide is very helpful, but this one in particular is relevant to read:* https://learning.postman.com/docs/getting-started/sending-the-first-request/
- Very in-depth article about model binding: https://www.dotnettricks.com/learn/webapi/model-binding-model-binder-example
- Microsoft docs about data transfer objects: https://learn.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-5
- Microsoft docs on the HttpContext class: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/use-http-context?view=aspnetcore-8.0
- Mozilla docs on response status codes: https://developer.mozilla.org/en-US/docs/Web/HTTP/Status
- *Article on how to build custom data annotations (here called **validation attributes**):* https://www.c-sharpcorner.com/UploadFile/abhikumarvatsa/custom-data-annotations-or-custom-validation-attributes-in-m/
