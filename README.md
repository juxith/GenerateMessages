Message Generator V0.1.0

Welcome to the Message Generator!

About:
Message Generator allows a user to generate messages from templates. The user can select pre-made templates or create new templates of their own. Templates contain placeholders that are populated with the appropriate information once generated. This application was modeled after a hotel servicing company.

Requirements: 
This project requires the .NET 4.5.1. framework and Internet Information Services Express. Clone this repository to your local machine and deploy the application. 

Instructions:
To generate a message, select a guest, a company and a template. Upon selection of template, a preview of message displays. Next, press “Generate”, a generated message will appear. All selections are required.
To create a new template, enter a new template name then create new message template. Select greeting radio button if you’d like the message to start with appropriate greeting such as “Good morning”. The greeting is calculated depending on the time of the day the message will be sent. The hours between 12AM to 11:59AM will read “Good morning”, 12PM to 4:59PM will read “Good afternoon”, and 5PM to 11:59PM will read “Good evening”. Add placeholders to message by clicking on placeholder buttons and remove placeholders by delete all placeholder characters. All placeholders are contained in curly brackets. Template name and message input are required to create new template. Press “Create Template” and JSON file will be updated, the newly created template will be selected and previewed. 

Design:
In this project, I created a single page, dynamically loaded web application using Web API. It would provide instant results for real time interaction. The application was built using a factory design pattern utilizing dependency injection for future extensions. By using an N-tier architectural design, I am separating the business logic layer from my models and user interface. For future implementations, it gives the application flexibility to swap out the components of the application such as integrating a database, or changing the user interface. This also allows for scalability and ease of maintenance.
I used .NET and jQuery frameworks because I was most proficient with them however, I am aware there are other frameworks and languages that are better suited for web applications. 
To handle edge cases and verify correctness, I initially built the application with mock data and wrote unit tests. I handled errors using try, catch blocks and added validation.

Future Implementations:
If I had more time to work on this project I would instead use a database for better relational mapping of objects. I’d want to make actual deployable messages and allow for documentation of deployed messages. I’d want to extend CRUD operations and provide a better UI for user experience. Given that this would be an application built for clients, I’d add authentication for security purposes.

Revision:
Version 0.1.0 12/13/2017 Initial version
