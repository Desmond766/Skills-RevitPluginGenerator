---
kind: type
id: T:Autodesk.Revit.DB.UpdaterRegistry
source: html/4f24f516-5274-1420-f255-458c0af5d318.htm
---
# Autodesk.Revit.DB.UpdaterRegistry

An object that stores and manages all updaters registered in the current session.

## Syntax (C#)
```csharp
public class UpdaterRegistry : IDisposable
```

## Remarks
The registry is an application-wide singleton. It maintains all dynamic
 updaters currently registered, and also invokes them per their respective
 trigger condition during subsequent transactions.
 Please note that only the application (an add-in, typically) which registered
 an updater is allowed to modify it later, including unregistering it.
 Also, an application is not allowed to register an updater with an Id,
 that is based on another application's Id.

