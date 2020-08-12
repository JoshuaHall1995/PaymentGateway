ReadMe

Running Acceptance Tests:
- Right click run the Function App
- Cd to the Acceptance Tests directory and type “nom test”


Reading the spec I saw two possible approaches for routing and differentiating the intent of payment requests.

The first, was to create a contract like “{paymentType}/payment” which extracted the value of payment type and from their routed the request onto whichever place was ready to handle its logic. This could be a disgusting switch statement, with hundreds of options in a coupled mess, or more realistically passed onto a queue/event hub where each individual service is waiting listening to see if it is a request of their type to pull it off and go about its life.

From here another endpoint, like the GET, could be used to constantly poll Theo there endpoint until the payment is found and then return success or failure based on what is stored, 

But this is not efficient or scalable.

The other idea, which I opted, is to imagine this service lives inside of a wider each-system behind an API gateway. The paymentType is used to route the requests to say a “Apple Service” etc depending on type and fro where each is set up to call the third-party api directly, with specific rules.

This is nice and decoupled, talks to the API’s directly and removes a lot of additional logic for routing. Of course this requires hundreds of services for hundreds of banks. But this is the fun of MicroServices. At least if Apple dies because of a messed up PR the other services are alive and well.

Authentication
So with the solution behind an imaginary API gateway we needed imaginary authentication. The routing in the API Gateway should accept a MerchantId and a UserId of the account that authorised the payment. 

This would allow us, via an Identify system, to check the claims of a user making a request to ensure a Google employee cannot request an Apple payment. 

Plus the standard Host Key authentication malicious payment attempts should be less likely.


Test bank
With the test bank I had two options. The simplest would be a dummy little service, maybe writing to some cheap storage, which does no authentication we could deploy to a develop environment and configure the PaymentGateway to look at via variables passed in from test running or local.setttings depending how you like to configure a environment for local testing.

The other option was to create a side project which can be ran up locally, say integrated with a build script that the solution can be told to point at. This would be easier for dockerisation and testing in a decoupled enviroment. Just depends how much you want to embrace the cloud environment it is hosted in. 

Explain how what I did is not what I would want to do.
 

Logging/ Duplication
Imagining this service is designed for high use and thousands of transactions the use of inline logging directly would just be expensive and slow the service. Instead with the use of something like ApplicationInsights and different logger settings we could set the service up to share records based on system chosen sampling options (in theory, in practice this still seems a little expensive).

The other option I prefer is to create a simple Transaction table to work as almost a log. All it would do is pump a copy of the request into a cheap storage table (like Blob or an Amazon alternative) so we can have an overview of all the requests sent and when for all of our services in one place.

This would be useful for reporting as it puts all of our information on transactions in one place (even if it is only as reliable as our system).

A benefit of this would be, although a slowing factor, that we could query this table to check for duplicates before each payment. This would take away the need for the stoppage of duplicate payments belonging to the third party API. 

In the project the ITransactionRepo represents this. In a real environment this would be stored in a separate project, saved to a NuGet Package each service would inherit. I have opted to pass in the ConnectionString for where it would be stored in each environment. This could be done in the place the package is setup if we dont plan on it changing.

Testing
Unit Tests were written to cover the Business Rules of the two endpoints required, which is tried to keep in the handler, and the validator which checks the request body received is as expected. 

Integration Tests or Database tests, people use many names, would be needed around the transaction repo but as this would not live in this project usually I ommitted them.

Acceptance tests, which are designed to call the Http Endpoints without touching the gateway, would be written in Cucumber. This is just a personal preference to ensure the requirements match business requirements and no code is reused between the testing and the main project. 
