---
kind: type
id: T:Autodesk.Revit.DB.LoadOperationType
source: html/ef5d6ee8-e822-264a-b0fd-174935999f72.htm
---
# Autodesk.Revit.DB.LoadOperationType

An enum indicating whether a resource load operation was triggered by
 a user action or an automatic process.

## Syntax (C#)
```csharp
public enum LoadOperationType
```

## Remarks
This enum is provided so that an external resource server can
 decide how much feedback it wishes to provide to the user. For example, Revit automatically loads all resources on file open.
 This may cause many external resources to load at once. The server
 may wish to provide truncated error messages. Reload() and LoadFrom() operations from the API are considered to
 be LoadOperationType.Explicit.

