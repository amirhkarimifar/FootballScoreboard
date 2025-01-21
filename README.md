# Football World Cup Scoreboard

This is a simple implementation of a Football World Cup Scoreboard as a library. The solution follows Clean Architecture, SOLID principles, and Domain-Driven Design (DDD) while keeping the implementation simple and functional.

### Features 

Start a game (initial score 0-0).
Update the score using game events (e.g., goals).
Support for match status (e.g., In Progress, Halftime, Finished).
Support for game events (e.g., Goals, Assists, Substitutions).
VAR functionality to revert a goal.
Get a summary of matches sorted by total score and recency.

### Technologies Used

- C# (.NET Core) – Backend logic
- jQuery & Bootstrap – Frontend UI
- MSTest/xUnit – Unit testing
### Project Structure
-Domain Layer: Core business logic (Entities, Aggregates, Value Objects).
-Application Layer: Use cases, DTOs, Services.
-Infrastructure Layer: In-memory repository for data storage.
-Presentation Layer: MVC with Razor, jQuery, and Bootstrap.
 
#### Assumptions
The system uses an in-memory store for simplicity.
No persistence (database) is implemented as per the requirements.
UI is kept minimal, focusing on functionality rather than design.
### Tests
The project follows Test-Driven Development (TDD).
Unit tests cover almost all critical operations (starting a game, updating scores, handling events, and game summaries).