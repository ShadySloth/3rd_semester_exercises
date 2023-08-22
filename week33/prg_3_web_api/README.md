### Presentation topics:

- The client-server model
- Hypertext transfer protocol
- HTTP clients [Limited to GET type requests for today]
    - Sending requests from Swagger
- HTTP servers [Limited to GET endpoints]
    - .NET Web API 
- JSON & serialization + deserialization
- Parameter binding

**Recommended actions:**
- Prioritize completing the exercises from yesterday (except for hard LINQ)
- Then do the exercises "FirstWebAPI"

## Important: .NET 8 uses another default layout, so i recommend cloning this repo with version 8 and controllers:

```bash
git clone https://github.com/uldahlalex/dotnetwebapi
```
Slides:
https://docs.google.com/presentation/d/e/2PACX-1vQqi0RqcQ2VB23NxttSVPhp0KpCKPEWgWcR_9xY1Dh9-dfTWQ1xivTuDwQFJ-auvm2f73k2KYxcQJfn/pub?start=false&loop=false&delayms=3000

### Relevant literature & documentation (high priority in *italics*):
- *Mozilla docs: Overview of HTTP*: https://developer.mozilla.org/en-US/docs/Web/HTTP/Overview
- .NET docs: Controller-based Web APIs: https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-8.0 *(High priority: Overview )*
- *Many of the concepts we're working with today is demonstrated in my video series (video 1):* https://www.youtube.com/watch?v=xtFXKAKkWRo&ab
- *Mozilla docs on JSON*: https://developer.mozilla.org/en-US/docs/Learn/JavaScript/Objects/JSON
- Although this example is using Minimal API and not controllers, it covers how to perform parameter binding (almost the exact same with controllers): https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/parameter-binding?view=aspnetcore-8.0

If you're curious about the "REST" debate and how to describe the type of application we're building, this article may be interesting to you: https://htmx.org/essays/how-did-rest-come-to-mean-the-opposite-of-rest/ (warning: does contain many abbreviations, acronyms, API terminology we haven't encountered yet, but I want to share it nevertheless)