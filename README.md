# Blazor Server State Management

## Introduction

> This highlights 3 different ways in which state can be managed on a Blazor Server Project.

## Code Samples

> Example one in the code shows how it can be done with a few lines of Javascript -
``` javascript
﻿window.stateManager = {
	save: function (key, str) {
		localStorage[key] = str;
	},
	load: function (key) {
		return localStorage[key];
	},
	remove: function (key) {
		localStorage.removeItem(key);
    }
};
```

> Examples 2 and 3 use the Nuget Package:
``` Microsoft.AspNetCore.ProtectedBrowserStorage ```. You can read more on it [here!](https://docs.microsoft.com/en-us/aspnet/core/blazor/state-management?view=aspnetcore-3.1)

## Installation

> Simply clone the project, open the solution, build and run!
