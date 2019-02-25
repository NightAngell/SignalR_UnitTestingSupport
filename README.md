> For the latest versions of NUnit version see: https://www.nuget.org/packages/SignalR.UnitTestingSupport.NUnit/

> For the latest versions of xUnit version see: https://www.nuget.org/packages/SignalR.UnitTestingSupport.xUnit

> For the latest versions of MSTest version see: https://www.nuget.org/packages/SignalR.UnitTestingSupport.MSTest/

> For full docs see: https://github.com/NightAngell/SignalR_UnitTestingSupport/wiki

# What it is?
This lib provide support objects and base classes for testing ```Hub, Hub<T>, IHubContext<T>, IHubContext<T, P>```. For example preconfigured mocks and helpfull verify methods. There is also support for testing Hubs and IHubContexts with ```Entity Framework Core```.

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
> All IHubContext support classes are in ```SignalR_UnitTestingSupportCommon.IHubContextSupport``` namespace

> For NUnit: All testing base classes are in ```SignalR_UnitTestingSupport.Hubs``` namespace

> For xUnit: All testing base classes are in ```SignalR_UnitTestingSupportXUnit.Hubs``` namespace

> For MSTest: All testing base classes are in ```SignalR_UnitTestingSupportMSTest.Hubs``` namespace

## 1) Base classes approach (Recommended)

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
#### 5. For testing with ```IHubContext<THub>``` see [this](https://github.com/NightAngell/SignalR_UnitTestingSupport/wiki/Associated-with-IHubContext-for-Hub).
#### 5. For testing with ```IHubContext<THub, TIHubResponses>``` see [this](https://github.com/NightAngell/SignalR_UnitTestingSupport/wiki/Associated-with-IHubContext-for-HubT).

## 2) Testing objects approach (Alternative, if you can't use base classes). 
How use second approach. See [this](https://github.com/NightAngell/SignalR_UnitTestingSupport/wiki/How-use-testing-support-if-you-don't-want-(or-you-can%60t)-use-provided-by-me-base-classes-or-your-testing-framework-don't-support-before-and-after-each-test-code-execution-features).
## For full docs see: [Docs](https://github.com/NightAngell/SignalR_UnitTestingSupport/wiki)
