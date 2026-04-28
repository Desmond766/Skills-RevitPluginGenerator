---
kind: method
id: M:Autodesk.Revit.DB.FilledRegion.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop})
zh: 创建、新建、生成、建立、新增
source: html/ca304caa-7f95-4638-67d9-a138be609b9f.htm
---
# Autodesk.Revit.DB.FilledRegion.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a view-specific filled region from the given boundaries.

## Syntax (C#)
```csharp
public static FilledRegion Create(
	Document document,
	ElementId typeId,
	ElementId viewId,
	IList<CurveLoop> boundaries
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to create the filled region.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - The filled region type Id.
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The view Id.
- **boundaries** (`System.Collections.Generic.IList < CurveLoop >`) - The boundaries.

## Returns
The newly created filled region.

## Remarks
View-specific filled regions can be created in models and 2d families.
 The line style of the boundaries will be set to thin lines by default.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The document is a 3d model family.
 -or-
 The Id typeId is invalid.
 -or-
 Details can't be drawn in the view.
 -or-
 Masking regions and Filled regions can't be created in this document or view.
 -or-
 The input curve loops cannot compose a valid boundary, that means:
 the "curveLoops" collection is empty;
 or some curve loops intersect with each other;
 or each curve loop is not closed individually;
 or each curve loop is not planar;
 or each curve loop is not in a plane parallel to the view's detail sketch plane;
 or input curves contain at least one helical curve.
 -or-
 Thrown if the viewId or typeId is invalid, or the view does not support
 the detail items creation, or if the boundaries are empty, open, or self-intersecting.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

