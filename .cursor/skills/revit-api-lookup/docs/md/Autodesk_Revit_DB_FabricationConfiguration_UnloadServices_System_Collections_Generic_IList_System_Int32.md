---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.UnloadServices(System.Collections.Generic.IList{System.Int32})
source: html/65e9d8c8-0371-8397-3a50-ec155e189999.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.UnloadServices Method

Unload the specified fabrication services from the project.

## Syntax (C#)
```csharp
public void UnloadServices(
	IList<int> serviceIds
)
```

## Parameters
- **serviceIds** (`System.Collections.Generic.IList < Int32 >`) - The identifiers of the fabrication services to unload.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Fabrication services can not be unloaded if they are in use currently.
 -or-
 Some services are not loaded yet.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The current fabrication configuration is not connected and updated to source configuration. Reload and try again.

