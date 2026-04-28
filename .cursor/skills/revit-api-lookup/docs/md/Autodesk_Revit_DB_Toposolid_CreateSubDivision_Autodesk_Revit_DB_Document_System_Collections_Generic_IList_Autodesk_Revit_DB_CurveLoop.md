---
kind: method
id: M:Autodesk.Revit.DB.Toposolid.CreateSubDivision(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop})
source: html/6120f56d-5fa1-5682-587f-7e790b73f43a.htm
---
# Autodesk.Revit.DB.Toposolid.CreateSubDivision Method

Create a toposolid subdivision element with the current toposolid as its host.

## Syntax (C#)
```csharp
public Toposolid CreateSubDivision(
	Document document,
	IList<CurveLoop> profiles
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the new toposolid is created.
- **profiles** (`System.Collections.Generic.IList < CurveLoop >`) - An array of planar curve loops that represent the profiles of the toposolid.

## Returns
The toposolid subdivision object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input curve loops cannot compose a valid boundary, that means:
 the "curveLoops" collection is empty;
 or some curve loops intersect with each other;
 or each curve loop is not closed individually;
 or each curve loop is not planar;
 or each curve loop is not in a plane parallel to the horizontal(XY) plane;
 or input curves contain at least one helical curve.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

