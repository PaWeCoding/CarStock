# CarStock
## Getting Started
1. Clone the repository
```
git clone https://github.com/PaWeCoding/CarStock.git
```
2. Open the solution <em>Car.sln</em> in any IDE you like, build and run ("F5" in most IDEs)
-> Once started, the app will book in a random number of cars (5 \<= count \<= 10) with random brands and years (1980 \<= year \<= current year) and prints the stock to the console afterward, thus no manual interaction is required. If not satisfied with the randomized console output, it is worth to restart the app.
## Documentation
The documentation can be found in the "_Docs" solution folder and contains the original task as "docx" as well as a class diagram created with **draw.io**. The file can be opened in the browser with https://app.diagrams.net/, alternatively I have also added the class diagram as PDF file.
## Software Design
The main entities are the <em>Car</em> (abstract CarBase in class diagram and code) as aggregate root as well as the <em>Tyre</em>. To ensure the overall consistency and correctness of all <em>Car</em> instances, the invariants for Ford and VW are realised as inherited entities of <em>Car</em>, named <em>FordCar</em> and <em>VWCar</em>.

The **factory pattern** is used for handling the instantiation of new cars. The factory uses optional action delegates with config models for an easy-to-use configuration of the cars.

The class <em>CarStockService</em> is designed as high-level service to book in cars as well as to read the current stock ordered by year (descending order, latest to oldest). This service could be used for any upcoming stock related use case.

The class <em>CarRepository</em> is responsible for the **in-memory** persistance of the cars. It follows a "CRUD" like approach, currently only supporting inserting and reading of cars. The return value when reading the cars with the <em>GetAll()</em> method is of type "IQueryable\<T>", which allows to apply additional filters before evaluating the actual result set.
## Project Structure
The project follows a **clean architecture** approach, meaning in this case that each layer only "knows" the contracts (interfaces / models) of the layer below but no concrete interface implementation. On the other hand, lower layers are not allowed to have any dependency to layers above. The only project which brings everything together is the actual console app <em>Car.App.csproj</em>, this is why this project needs to have a dependency to all the layers.

The layers are as follows (top down):
- **UI**
-> Contains logic for handling any user interaction (input and output where required). This layer is realised by the console app in this case
- **Core**
-> Contains the main business logic
- **Infrastructure**
-> Contains services for the persistency of the entities

Each layer (besides the UI layer) consists of three different projects:
- **Car.\<Layer>.csproj**
-> Contains the actual logic of the layer
- **Car.\<Layer>.Abstractions.csproj**
-> Contains the contracts (interfaces / models) of the layer
- **Car.\<Layer>.Tests.csproj**
-> Contains unit tests for the logic of the layer
## About the Code
The code follows the **clean code** principles, meaning that the code is written in a way that it is self-explanatory in terms of expected functionality (including SRR), naming, structure, complexity and general code size. Comments are only used to further explain some parts of the code where needed AND to highlight locations where assumptions were made.
## Testing
The test projects <em>Car.Core.Tests.csproj</em> and <em>Car.Infrastructure.Tests.csproj</em> contain several unit tests for the major logic in the application. The tests are built using **MSTest** and **NSubstitute** in a way that each test is only dependent on the logic of the currently tested unit to ensure best possible test isolation.
## Some Thoughts about Future Improvements
- It might be worth to add the NuGet package "Fluent Assertions" to the test projects (https://fluentassertions.com/), which enables more enhanced and most importantly **fluent** assertions to the unit tests for better readability and overall maintainability
- In production grade projects, I usually use dependency injection such as "MS ServiceCollection / ServiceProvider" or any other well-known DI framework to achieve a better decoupling of dependencies between the services