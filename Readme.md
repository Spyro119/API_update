#Readme.md 

To filter unique cities ; https://rocketelevatorsrestapisj.azurewebsites.net/api/addresses/city

To fetch all buildings :  https://rocketelevatorsrestapisj.azurewebsites.net/api/buildings
building by customers : https://rocketelevatorsrestapisj.azurewebsites.net/api/buildings/AlexaBuildings/{customer_id}

To fetch customers : https://rocketelevatorsrestapisj.azurewebsites.net/api/customer 
unique customers : https://rocketelevatorsrestapisj.azurewebsites.net/api/customer/id

To fetch employees : https://rocketelevatorsrestapisj.azurewebsites.net/api/employees/
All Employees with an Ai profile for identification : https://rocketelevatorsrestapisj.azurewebsites.net/api/employees/profiles

All Employees whitout AI profile : https://rocketelevatorsrestapisj.azurewebsites.net/api/employees/profile/null
Employees search by AI profile : https://rocketelevatorsrestapisj.azurewebsites.net/api/employees/profile/<identificationProfileId From Speaker recognition API results>
Ex : https://rocketelevatorsrestapisj.azurewebsites.net/api/employees/profile/c408b390-3947-46cb-8975-e41ffc14ad8a


=================================================================================================================================
For my API, there are the get methods links : 
To fetch all interventions : 
GET https://rocketelevatorsrestapisj.azurewebsites.net/api/interventions/

To fetch interventions by Id : 
GET https://rocketelevatorsrestapisj.azurewebsites.net/api/interventions/{id}

To fetch only pending interventions : 
GET https://rocketelevatorsrestapisj.azurewebsites.net/api/interventions/pending/


Put method here : 
PUT https://rocketelevatorsrestapisj.azurewebsites.net/api/interventions/{id} 
in postman, you'll need to have this in the pre-request body 
var current_timestamp = new Date();
postman.setEnvironmentVariable("current_timestamp", current_timestamp.toISOString());
 
and also need to copy the body of your interventions when fetching it by id, and put it in the body of your put method 
as such 

{
    "id": 24,
    "author": 51,
    "customer_id": 3,
    "building_id": 14,
    "battery_id": null,
    "elevator_id": null,
    "employee_id": 14,
    "start_datetime": "{{current_timestamp}}",
    "end_datetime": null,
    "result": "incomplete",
    "status": "in progress",
    "report": "Final test for real!"
}

The "{{current_timestamp}}" will register the current date and add it to the field.