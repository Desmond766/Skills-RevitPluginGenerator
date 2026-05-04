---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.LoadServices(System.Collections.Generic.IList{System.Int32})
source: html/893d7a24-0fd6-410f-2459-99c3b16fbfe0.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.LoadServices Method

Loads the specified fabrication services into the project.

## Syntax (C#)
```csharp
public IList<int> LoadServices(
	IList<int> serviceIds
)
```

## Parameters
- **serviceIds** (`System.Collections.Generic.IList < Int32 >`) - The identifiers of the fabrication services to load.

## Returns
The identifiers of the fabrication services which failed to load.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The current fabrication configuration is not connected and updated to source configuration. Reload and try again.
 -or-
 this operation failed.

