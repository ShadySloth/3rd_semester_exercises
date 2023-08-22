### Presentation topics:
- (Micro) Object-Relational-Mappers with Dapper
- PostgreSQL with ElephantSQL
- Npgsql (connection library from Nuget)
- Brief introduction to Datagrip

**Recommended actions:**
- Sign up for a free managed database plan at https://www.elephantsql.com or run a Postgres database from another vendor or locally on your own machine. PICK AMAZON WEB SERVICES IN STOCKHOLM, SWEDEN.
- Install some sort of database navigator tool capable of sending request to a Postgres database. (I recommend Jetbrains Datagrip or simply using the extension inside Rider)
- Do the exercises in the same directory as this readme file.

Tip: There is a diagram of the table in this directory (screenshot png file).

SLIDES: https://docs.google.com/presentation/d/e/2PACX-1vRif0n0ApeOqfg4jUJZXUoNpfW6K86NrTKM2Ih9czQmAS2TUjhY67H31di98lPz16ADvONTMR1aKax1/pub?start=false&loop=false&delayms=3000

### Literature & documentation (high priority reading is in *italics*):
- ElephantSQL getting started: https://www.elephantsql.com/docs/index.html
- *Npgsql docs: Getting started:* https://www.npgsql.org/doc/index.html *(I recommend reading this one, installation and basic usage chapters)*

### Relevant info about the exercises:
- This is a "implement the method and make the test pass"-style exercise
  - The tests not only check if you correctly return - they check that you modify the database correctly
  - There are guided solutions to many of the exercises
    - You can switch between guided solution and your solution for tests by changing the value in Helper.cs (called "mode")
  - They are in increasing order of difficulty
- In order to run tests which require a database connection, you must add a connection string to your test runner
  - In Jetbrains Rider, Settings -> Build, execution, deployment -> Unit testing -> Test runner, scroll down to environment variables, add pgconn with you connection string value.
  - Just use (one of) the data source(s) located in the Helper.cs class to open a connection
- There is a database schema which you must use
  - The database is automatically rebuilt using this schema in the beginning of every test
  - There are query models in the Models.cs file