#Readme.md 

To filter unique cities ; https://rocketelevatorsrestapisj.azurewebsites.net/api/addresses/city

To fetch all buildings :  https://rocketelevatorsrestapisj.azurewebsites.net/api/buildings
building by customers : https://rocketelevatorsrestapisj.azurewebsites.net/api/buildings/AlexaBuildings/{customer_id}

To fetch customers : https://rocketelevatorsrestapisj.azurewebsites.net/api/customer 
unique customers : https://rocketelevatorsrestapisj.azurewebsites.net/api/customer/{{id}}

To fetch quotes : https://rocketelevatorsrestapisj.azurewebsites.net/api/quotes
Not yet customers :  https://rocketelevatorsrestapisj.azurewebsites.net/api/quotes/notyetcustomer
Number of quotes : https://rocketelevatorsrestapisj.azurewebsites.net/api/quotes/total

To fetch batteries : https://rocketelevatorsrestapisj.azurewebsites.net/api/batteries

to fetch elevators :  https://rocketelevatorsrestapisj.azurewebsites.net/api/elevators
 inactive elevators : https://rocketelevatorsrestapisj.azurewebsites.net/api/elevators/inactiveelevators

To fetch leads : https://rocketelevatorsrestapisj.azurewebsites.net/api/leads/
total number of leads : https://rocketelevatorsrestapisj.azurewebsites.net/api/leads/total



=================================================================================================================================
For my API, there are the get methods links : 
To fetch all interventions : 
GET https://rocketelevatorsrestapisjb.azurewebsites.net/api/interventions/

To fetch interventions by Id : 
GET https://rocketelevatorsrestapisjb.azurewebsites.net/api/interventions/{id}

To fetch only pending interventions : 
GET https://rocketelevatorsrestapisjb.azurewebsites.net/api/interventions/pending/


Put method here : 
PUT https://rocketelevatorsrestapisjb.azurewebsites.net/api/interventions/{id} 
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
