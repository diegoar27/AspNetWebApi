## InsuranceCompany API

As a insurance company we've been asked to develop an application that
manage some information about our insurance policies and company clients.
To do that, we have two services that provide us with all the data needed:
* The list of company clients can be found at:
http://www.mocky.io/v2/5808862710000087232b75ac
* The list of company policies can be found at:
http://www.mocky.io/v2/580891a4100000e8242b75c5
With that information, we need to create a Web API that exposes services
with some constraints:
* Get user data filtered by user id -> Can be accessed by users with role
"users" and "admin"
* Get user data filterd by user name -> Can be accessed by users with role
"users" and "admin"
* Get the list of policies linked to a user name -> Can be accessed by
users with role "admin"
* Get the user linked to a policy number -> Can be accessed by users with
role "admin"

## Frameworks and Libraries
	- [ASP.NET Core 2.1]
	- [AutoMapper] (for mapping resources and models)
	- [Newtonsoft.Json 12.0.2] (Serialize and deserialize any .NET object/string.) 
## Endpoints

	/api/clients/{id}
		- To get client by id
	/api/clients/getbyname/{name}
		- To get client by name
	/api/clients/getbypolicynumber/{number}
		- To get policy by number 
	/api/policies/getbyusername/{name}
		- To get policy by user name

## TODO
	Authentication and authorization. Take the user role from the web service that returns the list of company clients
	- As pending, I should implement some way to authenticate a user/client.