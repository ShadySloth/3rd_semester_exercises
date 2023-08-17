### Get started with Postman

**Task:** Go through the "Get started" section subtopics:
- Welcome to Postman
- Postman first steps
    - Overview
    - Get the Postman app
    - Send your first APi request

Then move on to "sending requests", subtopics:
- Building requests
- Receiving responses
- Grouping requests in collections
- Using variables
https://learning.postman.com/docs/getting-started/first-steps/overview/

**Success criteria:** You should feel somewhat comfortable with using Postman to send HTTP requests.

**Learning objective:** The basics of navigating and using Postman to send HTTP requests and analyze responses.

### Import a request

**Task:** Import an HTTP request into Postman to analyze an HTTP request (and send it again).

<details  style="margin: 25px;">
  <summary>Click here to see guided solution</summary>

1. Open up Swagger when you have your Web API running. 

2. Now go to the networking tab of you browser (Right click the web page and press inspect to open up developer tools. Now locate the tab called "network"). 

3. Send an HTTP request from Swagger now with the network tab open. Now right click the HTTP request in the Developer tools and select "Copy as cURL". 
4. Go into Postman, and select file -> import and select "raw text". Now paste the copied cURL command. You may have to confirm again.

What data can you see about the HTTP request you sent from the Swagger page?

</details>

**Success criteria:** You should now have an HTTP request with tons of data (HTTP headers, maybe a payload, etc) visible in Postman. You should be able to click the send button to send the same request from Postman instead of your browser.

**Learning objective:** You must be able to use a tool like Postman to analyze HTTP requests and responses - and a relevant step is learning to import an HTTP request.

## Guided solutions for the rest of the exercises can be found in https://github.com/uldahlalex/dotnetwebapi in file Controllers/Day2Solutions


### Construct a Custom POST Endpoint


**Task:** Create a POST endpoint that takes a JSON body/payload and deserializes into a C# object. Return the same object.
**Success Criteria:** Using an HTTP client (like Swagger or Postman), you should be able to send JSON and receive it again.
**Learning objective:** You must know to make a POST endpoint that takes a custom DTO in the payload.

---

### GET with Custom (DTO) composed of different query params

**Task:** Construct a new GET endpoint that accepts an input/parameter of a custom type (data transfer object). This object should bind parameters from two or more query parameters (not the payload/body). The HTTP response body should include the data transfer object. (
```c#
[FromQuery] MyClass myObject
```
).

**Success Criteria:** You should be able to send an HTTP GET request with query parameters (api/route?queryparam=value&otherqueryparam=othervalue) and receive a JSON response containing the exact query parameters.

**Learning objective**: Using more complex parameter binding.

---

### Implement Data Annotations for the DTO


**Task:** Request a custom DTO. The DTO must have data annotations. Return 400 if the validation rules are violated. (Use [ApiController] attribute for the controller for "automatic" validation check)
**Success Criteria:** You should receive a status 400 response code when the data annotations are violated.

**Learning Objective:** Perform server-side data validation of client data.

---

### [ApiController] and exceptions

**Task:** Annotate a controller class with the [ApiController] attribute.
Return a "Bad request" response to a client by throwing an exception.

**Success criteria:** You should get a status code indicating an error

**Learning objective**: You should be able to make use of the [ApiController] attribute in order to send appropriate responses to the requester.


---


### Make a CRUD web API with in-memory database

Please be patient with this exercises - it may require some time. I have deliberately not created a guided solution for this one.

**Task:** Now that you know the basics of making API's, make a Web API which performs basic CRUD operations (without a database - just keep the data in memory).

The following features should be supported:

- Create new data
- Delete data
- Update data
- Get data

Basic server-side data validation must be existent (return status code 400 if your "rules" are violated).