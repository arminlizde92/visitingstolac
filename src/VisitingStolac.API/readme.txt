VisitingStolac.API Readme.txt

Project used mainly for writing the actual services

Folders:
Controllers: The service implementations. Services won't have any logic, only communication to the BLL (Business logic layer).
             Keep the services clean and only work with DTOs (Data transferable objects) => no entities.
             Exception handling will be handled by the exception middleware, in special cases consult with the architect.
             In all services despite the client side validation the objects have to be validated again. 
             Check for SQL-injection
IoC:         The Modules on which the app is going to run. AppModule communicates with the DB, while the MockModule
             only has mocked data inside the BLL.Mock project (used for testing frontend functionalities at first).
             The IoC modules can be registrated in the Startup.cs project. For adding new IoC modules consult with the 
             architect. Example of a new module is a BLL.SP (Business Logic Layer Stored Procedures).
Middleware:  This folder used for creating middlewares like the ExceptionMiddleware. After creating a middleware it's
             important to register it in the startup.cs, also keep the eyes open and check with the architect where the 
             middleware should be registered (exception middleware needs to be on first place).
             