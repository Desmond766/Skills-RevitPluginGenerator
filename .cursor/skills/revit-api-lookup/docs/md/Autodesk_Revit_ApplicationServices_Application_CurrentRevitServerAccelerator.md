---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.CurrentRevitServerAccelerator
source: html/b888a9ac-a5bf-5358-f23e-26f2927b93f3.htm
---
# Autodesk.Revit.ApplicationServices.Application.CurrentRevitServerAccelerator Property

Current Revit Server accelerator.

## Syntax (C#)
```csharp
public string CurrentRevitServerAccelerator { get; set; }
```

## Remarks
Revit connects with Revit Server hosts via current Revit Server accelerator.
 If current Revit Server accelerator is not set, this will be an empty string.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The server name can not be used to construct a well formed Uri string.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: When setting the value, Revit failed to write current Revit Server accelerator to the user environment.

