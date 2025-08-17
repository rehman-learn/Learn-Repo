using MiddlewareDemo.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();

//--------------middleware-------------------

app.UseMiddleware<RequestLoggingMiddleware>();

app.Map("/special", appBranch =>
{ 
    appBranch.Run( async context => 
    {  
        await context.Response.WriteAsync("This is a special branch of the middleware pipeline."); 
    });
});

app.UseMiddleware<EmailNotificationMiddleware>();
app.Run(async context =>
{
    // This is the final middleware in the pipeline
    await context.Response.WriteAsync("Hello from the final middleware!");
});

app.MapControllers();
app.Run();


/*
=========================   MIDDLEWARE – QUICK NOTES  =========================

Features and What it Does:
- Middleware is a component that is executed on every HTTP request.
- It is used to build a request processing pipeline in ASP.NET Core.
- Each middleware can perform logic before and/or after the next component executes.
- Middleware can inspect and modify the HttpContext.
- You can short-circuit the pipeline to stop further execution.
- Built-in helpers include Use(), Run(), and Map() for configuring the pipeline.
- Middleware order matters and affects how requests are processed.
- Middlewares are ideal for cross-cutting concerns (e.g. logging, authentication, error handling).

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Q1. What is middleware in ASP.NET Core?
A. Middleware is a reusable component that handles HTTP requests and responses. Each request goes through a pipeline of middleware components, where each component can perform actions 
   and decide whether to pass the request to the next one.

Q2. How do you register middleware in ASP.NET Core?
A. Middleware is registered in the Program.cs file using methods such as app.Use(), app.Run(), and app.Map().

Q3. What is the difference between Use(), Run(), and Map()?
A.
- Use(): registers middleware and continues to the next component.
- Run(): registers terminal middleware and does not call the next component.
- Map(): branches the pipeline based on the request path.

Q4. Why is the order of middleware important?
A. Because the request flows through the pipeline in the order middleware is registered. If a middleware short-circuits or performs modifications early, it will affect everything that executes after it.

Q5. What is short-circuiting in middleware?
A. This is when a middleware stops the request from continuing further down the pipeline (e.g. by returning a response immediately).

Q6. How do you access the HttpContext inside a middleware?
A. In the InvokeAsync method you get an HttpContext parameter which gives access to Request, Response, User, Headers, etc.

Q7. Can middleware modify the response?
A. Yes. Middleware can read and modify the response after the next middleware executes, which allows for logging, adding headers, or transforming the output.

Q8. What are common use cases for custom middleware?
A. Logging, authentication, exception handling, request/response modification, localization and metrics.

Q9. How do you create a custom middleware?
A. Create a class with a constructor that accepts RequestDelegate and implement an InvokeAsync(HttpContext) method. Register it in the pipeline using app.UseMiddleware<YourMiddleware>().

Q10. What happens if you register Map() before Use()?
A. Map() creates a separate branch. Middleware registered after the Map() call will not execute for requests that enter the branch unless you register them inside the branch.


---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
*/
