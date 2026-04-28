---
kind: method
id: M:Autodesk.Revit.DB.GlobalParametersManager.GetGlobalParametersOrdered(Autodesk.Revit.DB.Document)
source: html/e899f971-6c97-45e7-ac6d-cdac810e08e8.htm
---
# Autodesk.Revit.DB.GlobalParametersManager.GetGlobalParametersOrdered Method

Returns all global paramters in an ordered array.

## Syntax (C#)
```csharp
public static IList<ElementId> GetGlobalParametersOrdered(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document containing the requested global parameters

## Returns
An array of Element Ids of all Global Parameters in the document.

## Remarks
The order of the items coresponds to the order at which global parameters
 appear in Revit UI when shown in the standard Global Parameters dialog.
 However, the order of parameters is serialized in the document,
 thus available on the DB level as well.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Global parameters are not supported in the given document.
 A possible cause is that it is not a project document,
 for global parameters are not supported in Revit families.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

