---
kind: method
id: M:Autodesk.Revit.DB.Architecture.SiteSubRegion.Create(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop})
zh: 创建、新建、生成、建立、新增
source: html/b36074d6-01c1-805f-decc-153ead9a31a2.htm
---
# Autodesk.Revit.DB.Architecture.SiteSubRegion.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new SiteSubRegion element and adds it to the document.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2024 with the introduction of the new Toposolid elements.  It is recommended that Toposolid elements should be used in place of TopographySurface elements.")]
public static SiteSubRegion Create(
	Document document,
	IList<CurveLoop> curveLoops
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to be modified.
- **curveLoops** (`System.Collections.Generic.IList < CurveLoop >`) - The boundary of the subregion.

## Returns
The new SubRegion surface.

## Remarks
This will create a new TopographySurface element which represents a subregion.
 If you need access to this Element you can obtain it from TopographySurface .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input curve loops cannot compose a valid boundary, that means:
 no curve loop is contained in the given collection;
 these curve loops intersect with each other for some of them;
 or each curve loop is not closed individually;
 or each curve loop is not planar;
 or each curve loop is not in a plane parallel to the horizontal(XY) plane.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to create the Sketch for the boundary of the current Subregion.
 -or-
 Cannot find an appropriate host TopographySurface for the Subregion.
 -or-
 The given curve loops intersect with curve loops of existing SiteSubRegions hosted on the same TopographySurface.
 -or-
 The boundary of SubRegion is entirely inside or overlaps at least one existing BuildingPad hosted on the same TopographySurface. This behavior is not allowed.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

