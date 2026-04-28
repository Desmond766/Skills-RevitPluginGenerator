---
kind: method
id: M:Autodesk.Revit.DB.SolidSolidCutUtils.GetCuttingSolids(Autodesk.Revit.DB.Element)
source: html/ca21c6c1-7689-1a1e-f370-219eba29b8ff.htm
---
# Autodesk.Revit.DB.SolidSolidCutUtils.GetCuttingSolids Method

Gets all the solids which cut the input element.

## Syntax (C#)
```csharp
public static ICollection<ElementId> GetCuttingSolids(
	Element element
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The input element.

## Returns
The ids of the solids which cut the input element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

