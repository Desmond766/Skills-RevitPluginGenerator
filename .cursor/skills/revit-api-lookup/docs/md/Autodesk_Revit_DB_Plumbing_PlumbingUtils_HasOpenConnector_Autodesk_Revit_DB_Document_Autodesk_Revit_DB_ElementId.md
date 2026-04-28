---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PlumbingUtils.HasOpenConnector(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/fdcdf691-e9f3-3cf0-1b84-23cafdc4eae3.htm
---
# Autodesk.Revit.DB.Plumbing.PlumbingUtils.HasOpenConnector Method

Checks if there is open piping connector for the given element - object of pipe curve, pipe fitting or pipe accessory.

## Syntax (C#)
```csharp
public static bool HasOpenConnector(
	Document document,
	ElementId elemId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **elemId** (`Autodesk.Revit.DB.ElementId`) - Element id to check.

## Returns
True if given element has open piping connector, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

