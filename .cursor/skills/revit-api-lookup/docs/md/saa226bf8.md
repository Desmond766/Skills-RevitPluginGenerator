---
kind: method
id: M:Autodesk.Revit.DB.GlobalParametersManager.IsValidGlobalParameter(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/fe14085f-5643-db65-6cd7-05773be33c3b.htm
---
# Autodesk.Revit.DB.GlobalParametersManager.IsValidGlobalParameter Method

Tests whether an ElementId is of a global parameter in the given document.

## Syntax (C#)
```csharp
public static bool IsValidGlobalParameter(
	Document document,
	ElementId parameterId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the global parameter.
- **parameterId** (`Autodesk.Revit.DB.ElementId`) - Id of a global parameter

## Returns
Returns True if the Id is of a valid global parameter; False otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

