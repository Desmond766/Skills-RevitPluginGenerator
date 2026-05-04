---
kind: method
id: M:Autodesk.Revit.DB.Architecture.TopographySurface.Create(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ})
zh: 创建、新建、生成、建立、新增
source: html/824b6a30-f775-149f-2e6a-5198c5299d14.htm
---
# Autodesk.Revit.DB.Architecture.TopographySurface.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new topography surface element and adds it to the document.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2024 with the introduction of the new Toposolid elements.  It is recommended that Toposolid elements should be used in place of TopographySurface elements.")]
public static TopographySurface Create(
	Document document,
	IList<XYZ> points
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to be modified.
- **points** (`System.Collections.Generic.IList < XYZ >`) - A collection of points.
 The points represent an enclosed area in the XY plane.
 There can be only one point in the same XY location.

## Returns
The new topography surface.

## Remarks
The document will be regenerated during the creation of this topography surface element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 There are no points in the input points set.
 -or-
 There were not enough points to form a valid region (at least 3 are required), or the points were collinear ignoring elevation.
 -or-
 One or more points shared the same XY location (even with different elevations). This is not permitted for topography surfaces.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

