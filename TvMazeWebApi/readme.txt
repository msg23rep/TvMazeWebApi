

This is a Web Api based on .Net 8.0, it is divided in 3 layers: 
 - Controllers: for exposure of the Api endpoints, calling the login and returning the response
 - Services: for hosting the logic and connecting all the layers
 - Repository: for accesing the data (sql database), with Entity Framework in this case

Dependency Injection is used to instantiate efficiently all resources needed at any of the layers,
on every call

About the data model, its divided in two, the external Api model, wich mimics all the fields 
returned by the api in json format, and the entity model with the data needed to store in 
our database, these two are mapped with AutoMapper specifying the fields to map

For securization, an ApiKey is user for authorization via service filter and a controller 
method custom attribute. The apikey is expected at the request header.

Since the functionality is small, there is just one project, for something growing or larger, 
three more project could be more mantainable: Infrastructure (repositories, external api calls), 
Transversal(utils, attributes, mappers...), Domain (models, interfaces...)


For running the project just debug it with Visual Studio, making sure TvMazeApi is the 
starting project (the database connection string should work I hope)