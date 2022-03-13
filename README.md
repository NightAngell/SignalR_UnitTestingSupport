> For the latest versions of NUnit version see: https://www.nuget.org/packages/SignalR.UnitTestingSupport.NUnit/

> For the latest versions of xUnit version see: https://www.nuget.org/packages/SignalR.UnitTestingSupport.xUnit

> For the latest versions of MSTest version see: https://www.nuget.org/packages/SignalR.UnitTestingSupport.MSTest/

> For full docs see: https://github.com/NightAngell/SignalR_UnitTestingSupport/wiki

# What it is?
This lib provide support objects and base classes for testing ```Hub, Hub<T>, IHubContext<T>, IHubContext<T, P>```. For example preconfigured mocks and helpfull verify methods. There is also support for testing Hubs and IHubContexts with ```Entity Framework Core```.

# Which nuget version should I choose?
1. netcoreapp (2.1, 2,2, 3.0, 3,1) - 2.0.0
2. net5 - 5.0.0
3. net6.0 - 6.0.0

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
Install-Package SignalR.UnitTestingSupport.NUnit -Version 6.0.0
Install-Package SignalR.UnitTestingSupport.xUnit -Version 6.0.0
Install-Package SignalR.UnitTestingSupport.MSTest -Version 6.0.0
```
#### 3. Using .Net CLI
```
dotnet add package SignalR.UnitTestingSupport.NUnit --version 6.0.0
dotnet add package SignalR.UnitTestingSupport.xUnit --version 6.0.0
dotnet add package SignalR.UnitTestingSupport.MSTest --version 6.0.0
```
## Troubleshooting!
Install ```NUnit3TestAdapter``` nuget for visual studio testing with NUnit in visual studio.                     https://www.nuget.org/packages/NUnit3TestAdapter/

Install ```xunit.runner.visualstudio``` nuget for visual studio testing with xUnit.                                https://www.nuget.org/packages/xunit.runner.visualstudio/

Install ```MSTest.TestAdapter``` nuget for visual studio testing with MSTest.          
https://www.nuget.org/packages/MSTest.TestAdapter/

If your tests are not even detected, install ```Microsoft.Net.Test.Sdk``` nuget :)                       
https://www.nuget.org/packages/Microsoft.NET.Test.Sdk/

If you get NullReferenceException when you try testing with my lib see [this](https://github.com/NightAngell/SignalR_UnitTestingSupport/wiki/Common-for-all-test-classes#contextmock).

Error after update for ASP.NET Core 3.0:
[Help with migration from ASP.NET Core 2.1 or 2.2 to 3.0](https://github.com/NightAngell/SignalR_UnitTestingSupport/wiki/Help-with-migration-from-netcore2.1-or-netcore2.2-to-netcore3.0-for-SignalR_UnitTestingSupport2.0)

[Help with migration from netstandard2.0 to netstandard.2.1 compatibile project](https://github.com/NightAngell/SignalR_UnitTestingSupport/wiki/Help-with-migration-from-netstandard2.0-to-netstandars2.1)

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
