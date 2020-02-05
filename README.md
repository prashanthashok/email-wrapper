# email-wrapper

### Installation
	* Install [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)
	* Clone this repo
	* Open email-wrapper/email-wrapper.sln file and it opens the whole project in Visual Studio
	* Install [nodejs](https://nodejs.org/en/)
	* Install [Angular](https://angular.io/guide/setup-local)
	* To run the app, click the green play button (>IIS Express) in Visual Studio
	* The app should be running on localhost, and api should be available for POST at /api/email
		* If there are any problems with Angular/nodejs, 
			- navigate to ClientApp in a terminal 
			- run 'npm install' 
			- Once the node_modules have been installed, run 'npm start' to build the app
			- Once the build completes, navigate to http://localhost:4200/ to check if the UI runs separately without any issues
### Technologies used
	The reason for choosing this particular framework setup is because I am familiar with them the most
	* C# .Net Core for the back-end
	* Angular for the front-end
		- UI contains a simple form to send email
		- A health check to ensure API is up and running
	* xUnit for the testing framework and NSubstitute for providing mock interfaces
	
### Notes
	* Created Helper classes for each of the service providers 
	* Implemented Dependency Injection to provide Email Handlers at run time based on configuration
	* xUnit
		- Used xUnit as MSTest does not support testing async methods
		- Created a new class TestsBase implementing IDisposable interface in order to initialize mock objects before each test run
	
### Todo
	* (Done) Add configuration to switch between email providers 
	* (Done) Write unit tests https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing?view=aspnetcore-3.1
	* Git Track Credentials.cs, commit and then untrack again
	* Use App secrets to store API key - https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-3.1&tabs=windows
	* (Done) Fix object composition in MailGunHelper
	* Fix readme
	* (Done) Dependency injection
		- Add IEmailHandlerRepository
		- Add concrete implementation for EmailHandlerRepository 
		- Inject app config to EmailHandlerRepository 
		- Inject Func
		- and decide which EmailHandler implementation to return based on App Config
		- Resolve services in Startup.cs

	* Build UI
		* (Done) Process response from API
		* (Partial) UI validations
	
	* Add logging
	* Polish UI
		- UI Validations
		- UI spinner
	* Deploy app