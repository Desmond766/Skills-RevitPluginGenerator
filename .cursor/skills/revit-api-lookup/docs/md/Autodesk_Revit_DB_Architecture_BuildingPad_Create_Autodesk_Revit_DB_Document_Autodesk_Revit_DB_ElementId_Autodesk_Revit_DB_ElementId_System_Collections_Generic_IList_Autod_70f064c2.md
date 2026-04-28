---
kind: method
id: M:Autodesk.Revit.DB.Architecture.BuildingPad.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop})
zh: 创建、新建、生成、建立、新增
source: html/1ce6838d-9be0-df63-20cc-d3a2f6c70491.htm
---
# Autodesk.Revit.DB.Architecture.BuildingPad.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new BuildingPad element and adds it to the document.

## Syntax (C#)
```csharp
public static BuildingPad Create(
	Document document,
	ElementId buildingPadTypeId,
	ElementId levelId,
	IList<CurveLoop> curveLoops
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to be modified.
- **buildingPadTypeId** (`Autodesk.Revit.DB.ElementId`) - The type id set to the BuildingPad.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The level id set to the BuildingPad.
- **curveLoops** (`System.Collections.Generic.IList < CurveLoop >`) - The boundary of the BuildingPad.

## Returns
The new BuildingPad element.

## Remarks
The document will be regenerated during the creation of building pad element.
 If the input curve loops intersect the curve loops of existing BuildingPads hosted on the same topography surface,
 an InvalidOperationException will be thrown.
 If you need access to the topography surface created by the introduction of this building pad, you can obtain it from
 AssociatedTopographySurfaceId .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The buildingPadTypeId is not a valid type id for a BuildingPad.
 -or-
 The ElementId levelId is not a Level.
 -or-
 The input curve loops cannot compose a valid boundary, that means:
 no curve loop is contained in the given collection;
 these curve loops intersect with each other for some of them;
 or each curve loop is not closed individually;
 or each curve loop is not planar;
 or each curve loop is not in a plane parallel to the horizontal(XY) plane.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to create the Sketch for the boundary of new created BuildingPad.
 -or-
 Cannot find an appropriate hosting topography surface for this BuildingPad.
 -or-
 This topography surface cannot be the host of this BuildingPad.
 -or-
 The given curve loops intersect with curve loops of existing BuildingPads hosted on the same TopographySurface.
 -or-
 There is at least one existing SubRegion which is completely inside or overlap the boundary of current BuildingPad hosted on the same TopographySurface. This behavior is not allowed.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

