---
kind: method
id: M:Autodesk.Revit.DB.FilterElementIdRule.UsesLevelFiltering(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/bfa83fa8-304f-edd9-b74e-d9d60d689ade.htm
---
# Autodesk.Revit.DB.FilterElementIdRule.UsesLevelFiltering Method

This function checks if a parameter uses level filtering.

## Syntax (C#)
```csharp
public static bool UsesLevelFiltering(
	Document doc,
	ElementId parameterId
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document which owns the parameter.
- **parameterId** (`Autodesk.Revit.DB.ElementId`) - The id of the parameter that will be tested to see if it uses level filtering.

## Returns
True if the parameter uses level filtering, false otherwise.

## Remarks
When level-filtering parameters are compared, the comparisons will
 first compare the values of the levels' elevations, then compare the
 levels' names, and finally the levels' element ids to rank and sort the levels.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

