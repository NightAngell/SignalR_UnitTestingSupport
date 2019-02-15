# How to install it
> For the latest versions of nuget see: https://www.nuget.org/packages/SignalR.UnitTestingSupport.NUnit/
#### 1. Using Visual Studio Nuget Package Manager
> If you dont know how install nuget via Visual Studio see this: https://www.youtube.com/watch?v=jX5HlrerIos
```
SignalR.UnitTestingSupport.NUnit
```
#### 2. Using Packet Manager Console
```
Install-Package SignalR.UnitTestingSupport.NUnit -Version 1.0.0
```
#### 3. Using .Net CLI
```
dotnet add package SignalR.UnitTestingSupport.NUnit --version 1.0.0
```
## Important!
Install ```NUnit3TestAdapter``` nuget for visual studio testing. See: https://www.nuget.org/packages/NUnit3TestAdapter/

# How to use it
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
#### 3. For testing ```Hub``` with ```EntityFrameworkCore DbContext```
```csharp
class ExampleHubTests : HubUnitTestsWithEF<TDbContext> {}
```
> TDbContext is any class which inherit from ```Microsoft.EntityFrameworkCore.DbContext``` od DbContext itself.
#### 4. For testing ```Hub<T>``` with ```EntityFrameworkCore DbContext```
```csharp
class ExampleHubTests : HubUnitTestsWithEF<T, TDbContext> {}
```
> TDbContext is any class which inherit from ```Microsoft.EntityFrameworkCore.DbContext``` od DbContext itself.

### Important
```HubUnitTestsBaseCommon``` is internal class (it must be marked by code as public). Do not use it.

## For full docs see: [Docs](https://github.com/NightAngell/SignalR_UnitTestingSupport/wiki)
