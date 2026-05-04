---
kind: method
id: M:Autodesk.Revit.DB.Architecture.Railing.SetPath(Autodesk.Revit.DB.CurveLoop)
zh: 栏杆
source: html/2a1c1870-31f9-c80d-23b4-da44d0e86179.htm
---
# Autodesk.Revit.DB.Architecture.Railing.SetPath Method

**中文**: 栏杆

Sets the railing path.

## Syntax (C#)
```csharp
public void SetPath(
	CurveLoop curveLoop
)
```

## Parameters
- **curveLoop** (`Autodesk.Revit.DB.CurveLoop`) - The railing path along which the new railing will be created.
 The curveLoop should be continuous with curves which are only bounded lines and arcs on the same horizontal plane.
 It also has to have maximum two curves meet in one end point.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The curveLoop must be a single connected path, located on the same horizontal plane and defined using lines or arcs only.
 It also has to have maximum two curves meet in one end point.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InapplicableDataException** - The railing has incorrect internal data.

