---
kind: method
id: M:Autodesk.Revit.DB.GlobalParametersManager.GetAllGlobalParameters(Autodesk.Revit.DB.Document)
source: html/62b46073-1a11-0cc8-1798-8d6d87719888.htm
---
# Autodesk.Revit.DB.GlobalParametersManager.GetAllGlobalParameters Method

Returns all global parameters available in the given document.

## Syntax (C#)
```csharp
public static ISet<ElementId> GetAllGlobalParameters(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the global parameters

## Returns
A collection of Element Ids of global parameter elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Global parameters are not supported in the given document.
 A possible cause is that it is not a project document,
 for global parameters are not supported in Revit families.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

