---
kind: method
id: M:Autodesk.Revit.DB.FilledRegion.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.SketchPlane,System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop})
zh: 创建、新建、生成、建立、新增
source: html/2b534d9c-666e-b8a8-0af0-931029f72e9f.htm
---
# Autodesk.Revit.DB.FilledRegion.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a filled region on a sketch plane in a 3d model family.

## Syntax (C#)
```csharp
public static FilledRegion Create(
	Document document,
	ElementId typeId,
	SketchPlane sketchPlane,
	IList<CurveLoop> boundaries
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The family document in which to create the filled region.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - The filled region type Id.
- **sketchPlane** (`Autodesk.Revit.DB.SketchPlane`) - The sketch plane for use with the filled region.
- **boundaries** (`System.Collections.Generic.IList < CurveLoop >`) - The filled region boundaries, which will be projected onto the sketch plane.

## Returns
The new filled region.

## Remarks
If the sketch plane is currently in use, then a copy of the sketch plane will be created and used.
 The sketch plane normal must be parallel to the model's X, Y or Z axis.
 The sketch plane can be a planar face reference to model geometry.
 The line style of the boundaries will be set to thin lines by default.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The document is not a 3d model family.
 -or-
 The Id typeId is invalid.
 -or-
 Filled regions can't be created in this document or view.
 -or-
 The sketch plane is not suitable for model elements.
 -or-
 The sketch plane normal is not parallel to the model's X, Y or Z axis.
 -or-
 The input curve loops cannot compose a valid boundary, that means:
 the "curveLoops" collection is empty;
 or some curve loops intersect with each other;
 or each curve loop is not closed individually;
 or each curve loop is not planar;
 or each curve loop is not in a plane parallel to the sketch plane;
 or input curves contain at least one helical curve.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

