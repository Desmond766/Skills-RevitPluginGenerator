---
kind: method
id: M:Autodesk.Revit.DB.SolidSolidCutUtils.GetSolidsBeingCut(Autodesk.Revit.DB.Element)
source: html/4b8c8902-2a32-b99c-aa0e-e3abd79d9073.htm
---
# Autodesk.Revit.DB.SolidSolidCutUtils.GetSolidsBeingCut Method

Get all the solids which are cut by the input element.

## Syntax (C#)
```csharp
public static ICollection<ElementId> GetSolidsBeingCut(
	Element element
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The input element.

## Returns
The ids of the solids which are cut by the input element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

