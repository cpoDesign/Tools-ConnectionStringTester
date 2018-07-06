# Tools-ConnectionStringTester
Connection string tester application in .NET 4.6.1

Can be integrated with any tool you like. It will display error if it does not work.


# Commands supported:
```bat
tester.exe -c
```
Executes the test against your database.
 - Will not display any error if the configuration is correct
 - Will display exception if configuration is wrong
 
 
```bat
tester --help
```
Display list of all commands.

```bat
tester.exe --version 
```
Used to display application version.


#Example of the configuration for app config:
```XML
 <add name="ConnectionStringUnderTest" connectionString="Data Source=localhost;Initial Catalog=myDb;Integrated Security=True" />
 <add key="SqlCommand" value="select count(*) from (select * from dbo.TestingTable) as underTest" />
```
https://gist.github.com/cpoDesign/248c2b053054bef7ee282011ab68cc5c
