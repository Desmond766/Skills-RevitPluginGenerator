---
kind: method
id: M:Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.GetNumberOfPlacementPoints(Autodesk.Revit.DB.Family)
source: html/f5d9c527-3348-276c-039c-7de85b308bd9.htm
---
# Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.GetNumberOfPlacementPoints Method

Gets number of Placement Point Elements in Adaptive Component Family.

## Syntax (C#)
```csharp
public static int GetNumberOfPlacementPoints(
	Family family
)
```

## Parameters
- **family** (`Autodesk.Revit.DB.Family`) - The Family

## Returns
Number of Adaptive Placement Point Element References in Adaptive Component Family.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The Family family is not an Adaptive Component Family.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation failed.

