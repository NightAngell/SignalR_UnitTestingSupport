> For the latest versions of NUnit version see: https://www.nuget.org/packages/SignalR.UnitTestingSupport.NUnit/

> For the latest versions of xUnit version see: https://www.nuget.org/packages/SignalR.UnitTestingSupport.xUnit

> For the latest versions of MSTest version see: https://www.nuget.org/packages/SignalR.UnitTestingSupport.MSTest/

> For full docs see: https://github.com/NightAngell/SignalR_UnitTestingSupport/wiki
# How to install
#### 1. Using Visual Studio Nuget Package Manager
> If you dont know how install nuget via Visual Studio see this: https://www.youtube.com/watch?v=jX5HlrerIos
```
SignalR.UnitTestingSupport.NUnit
SignalR.UnitTestingSupport.xUnit
SignalR.UnitTestingSupport.MSTest
```
#### 2. Using Packet Manager Console
```
Install-Package SignalR.UnitTestingSupport.NUnit -Version 1.1.0
Install-Package SignalR.UnitTestingSupport.xUnit -Version 1.1.1
Install-Package SignalR.UnitTestingSupport.MSTest -Version 1.1.0
```
#### 3. Using .Net CLI
```
dotnet add package SignalR.UnitTestingSupport.NUnit --version 1.1.0
dotnet add package SignalR.UnitTestingSupport.xUnit --version 1.1.1
dotnet add package SignalR.UnitTestingSupport.MSTest --version 1.1.0
```
## Troubleshooting!
Install ```NUnit3TestAdapter``` nuget for visual studio testing with NUnit in visual studio.                     https://www.nuget.org/packages/NUnit3TestAdapter/

Install ```xunit.runner.visualstudio``` nuget for visual studio testing with xUnit.                                https://www.nuget.org/packages/xunit.runner.visualstudio/

Install ```MSTest.TestAdapter``` nuget for visual studio testing with MSTest.          
https://www.nuget.org/packages/MSTest.TestAdapter/

If your tests are not even detected, install ```Microsoft.Net.Test.Sdk``` nuget :)                       
https://www.nuget.org/packages/Microsoft.NET.Test.Sdk/

# How to use
After you add nuget to your test project, SignalR_UnitTestingSupport is ready to use.
Create test class for hub for example:
```csharp
class ExampleHubTests {}
```
And then:
#### 1. For testing ```Hub```
```csharp
class ExampleHubTests : HubUnitTestsBase {}
```
#### 2. For testing ```Hub<T>```
```csharp
class ExampleHubTests : HubUnitTestsBase<T> {}
```
#### 3. For testing ```Hub``` with ```EntityFrameworkCore```
```csharp
class ExampleHubTests : HubUnitTestsWithEF<TDbContext> {}
```
> TDbContext is any class which inherit from ```Microsoft.EntityFrameworkCore.DbContext``` or DbContext itself.
#### 4. For testing ```Hub<T>``` with ```EntityFrameworkCore```
```csharp
class ExampleHubTests : HubUnitTestsWithEF<T, TDbContext> {}
```
> TDbContext is any class which inherit from ```Microsoft.EntityFrameworkCore.DbContext``` or DbContext itself.

### Important
```HubUnitTestsBaseCommon``` is internal class (it must be marked by code as public). Do not use it.

## For full docs see: [Docs](https://github.com/NightAngell/SignalR_UnitTestingSupport/wiki)
