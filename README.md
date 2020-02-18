# email-wrapper

### About
	* This app provides an email-wrapper to use one of two email providers - MailGun and SendGrid (additional providers can be added) to send an email. 
	* In the event of an outage current email provider being used, changing the configuration and redeploying the app is enough to switch to the other email provider(s).
	* This app listens for POST request (currently local) at http://localhost:PORTNUMBER/api/email
	* This app also provides a utility UI to test the POST requests
	* In order to send emails using one of the two email providers, an API key needs to be registered with the email provider and added in the Credentials.cs
	* Please note that due to limitations, emails from MailGun can only be sent via the Sandbox created using the registered account
	
##### Example Request Payload:
```json
{
	"to" : "Jane Doe" ,
	"to_name" : "Mr. Fake" ,
	"from" : "noreply@example.com" ,
	"from_name" : "John Doe" ,
	"subject" : "A Message from Your Email Provider" ,
	"body" : "<h1>Your Bill</h><p>$10</p>"
}
```

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
	The reason for choosing this particular framework setup is due to my familiarity with them
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
	* (Done) Git Track Credentials.cs, commit and then untrack again
	
	* (Done) Fix object composition in MailGunHelper
	* (Done) Fix readme
	* (Done) Dependency injection
		- Add IEmailHandlerRepository
		- Add concrete implementation for EmailHandlerRepository 
		- Inject app config to EmailHandlerRepository 
		- Inject Func
		- and decide which EmailHandler implementation to return based on App Config
		- Resolve services in Startup.cs

	* (Done) Build UI
		* Process response from API
		* UI validations
	* Fix health check response. It currently works when accessed directly but is failing from the UI.
	* Add logging
	* Polish UI
		- UI Validations
		- UI loading spinner
	* Deploy app
	* Use App secrets to store API key - https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-3.1&tabs=windows
