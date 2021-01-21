# LifePremiumAPI/LifePremiumAPP

This is a small Blazor application that demonstrated how to initiate requests to an external api..

Solution contains:

* API to return occupations, factors and premium calculations
* Client UI to display user input controls and request to API 
* Services for hitting external apis
* Dependency injection with custom service classes
* uri in appsettings.json

Assumptions
* Premium calculations are based on the formula (Monthly Death Premium = (Death Cover amount x Occupation Rating Factor x Age) /1000 x 12)
* Best matched jobs are based on the number of distinct skills of the candidate skills against the job skills requirement.
* No other action required after the the premiumis calculated.

How to run
* Download and unzip to local
* Open solution  in Visual Studio 2019
* Update the solution to start multiple projects LifePremiumAPI and LifePremiumAPP
* Build and run

![Alt text](https://github.com/hph138/LifePremiumAPI/blob/master/screenshots/home.PNG "Home")
![Alt text](https://github.com/hph138/LifePremiumAPI/blob/master/screenshots/calculate.PNG "Calculate")
![Alt text](https://github.com/hph138/LifePremiumAPI/blob/master/screenshots/premium.PNG "Premium")
![Alt text](https://github.com/hph138/LifePremiumAPI/blob/master/screenshots/error.PNG "Error")
![Alt text](https://github.com/hph138/LifePremiumAPI/blob/master/screenshots/unittest.PNG "Unit Test")
