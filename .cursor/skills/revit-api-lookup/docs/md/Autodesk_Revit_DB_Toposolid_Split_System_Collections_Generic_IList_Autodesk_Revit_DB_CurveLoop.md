---
kind: method
id: M:Autodesk.Revit.DB.Toposolid.Split(System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop})
zh: 拆分、打断、分割
source: html/a7760dc6-515d-6ac2-6164-d0581c7d6dee.htm
---
# Autodesk.Revit.DB.Toposolid.Split Method

**中文**: 拆分、打断、分割

Split the toposolid by the given curve loops.

## Syntax (C#)
```csharp
public IList<ElementId> Split(
	IList<CurveLoop> splitCurveLoops
)
```

## Parameters
- **splitCurveLoops** (`System.Collections.Generic.IList < CurveLoop >`) - An array of planar curve loops that are used to split the toposolid.
 All of the curve loops should lie on the sketch plane of the toposolid.

## Returns
An array of newly created toposolid ids after split.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The split curve loops should all lie on the sketch plane of the toposolid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

