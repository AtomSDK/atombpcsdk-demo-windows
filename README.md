
# ATOM Business Policy Component SDK demo for Windows

This is a demo application that demonstrate how to use **BPC SDK** along with **ATOM SDK** 

BPC SDK provides the customizable inventory which enables you to offer different sets of entities to your end-users with the help of customized *Packages* and *Groups*. BPC SDK will also provide *Custom Attributes* that you can associate with every byte of system related data e.g. Countries data is Atom's property but through BPC, you can add Custom Attributes to Country's object like flag icon etc which enables to stay back-end-free and BPC will serve as your customized back-end.

# BPC Features explained in this Demo
* How to get Inventory filtered by Packages
* Some frequently used methods present in the SDK

 ## Compatibility
* Compatible with Microsoft Visual Studio 2015 and onwards
* Minimum .Net Framework 4.5 required
* Compatible with ATOM SDK Version 2.2.1 and onwards 


## SDK Installation

Install the latest version of Atom Windows BPC SDK through NuGet.
 
```
Install-Package Atom.BPC.Net -Version 1.1.0
```
 ## Enable Local Inventory Support (Mandatory and strongly recommended)
 
 ATOM BPC SDK offers a feature to enable the local inventory support. This can help Application to fetch Inventory even when device network is not working or in areas where there are URL blockages.

* To enable it, just start demo application with your Secret Key for the first time.
* A database file (.sdf) will be generated right at the executable directory.
* File name should be *localdata.sdf*. Please rename the file to *localdata.sdf* if you find any discrepancy in the file name.
* Make that database (.sdf) file the part of your package and it should be placed where BPC Dlls are placed (usually it is your installation directory).
 

# Getting Started with the Code
## Initialization
BPC SDK needs to be initialized with a “SecretKey” provided to you after you buy the subscription which is typically a hex-numeric literal.

```csharp
var atomConfiguration = new AtomConfiguration(“SECRETKEY_GOES_HERE”);
var bpcManager= await AtomBPCManager.InitializeAsync(atomConfiguration);
```
*Please note that another Initializer is available with a callback functionality. Explore more in inline documentation.*

# How to get Inventory related to customer's Package
BPC enables you to define and sell your customers your own choice of inventory by creating packages. Through BPC SDK, you can get complete inventory as well as get it filtered by your logged in customer's package. Following are some code examples to achieve the same: 


### Get All packages
Call this method to get all packages from your inventory 
```csharp
var packages = await bpcManager?.GetPackages();
```


### Get Countries filtered by Package
This function will retrieve all countries that are associated with a particular package 
```csharp
var countries = await bpcManager?.GetCountriesByPackage(PackageObject);
```

### Get Protocols filtered by Package
This function will retrieve all protocols that are associated with a particular package 

```csharp
var protocols = await bpcManager?.GetProtocolsByPackage(PackageObject);
```


# Some other functions that are helpful to retrieve common inventory items 

### Get all Countries
This function will provide the list of all countries present in your inventory
``` csharp
var countries = await bpcManager?.GetCountries();
```


### Get Countries filtered by Protocol
This function will provide you the list of countries that are mapped with a specific protocol
```csharp
var countries = await bpcManager?.GetCountriesByProtocol(protocolObject);
```


### Get all Cities
This function will provide the list of all cities present in your inventory
```csharp
var cities = await bpcManager?.GetCities();
```

### Get cities by protocol
This function will provide you the list of cities that are mapped with a specific protocol
```csharp
var cities = await bpcManager?.GetCitiesByProtocol(protocol)
```
