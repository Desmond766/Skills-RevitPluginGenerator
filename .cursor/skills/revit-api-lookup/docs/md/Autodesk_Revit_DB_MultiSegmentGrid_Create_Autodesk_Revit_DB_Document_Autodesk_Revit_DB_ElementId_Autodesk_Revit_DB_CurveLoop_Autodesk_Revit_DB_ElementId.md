---
kind: method
id: M:Autodesk.Revit.DB.MultiSegmentGrid.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.CurveLoop,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/706e504e-20dd-e017-6bdf-e5265848d150.htm
---
# Autodesk.Revit.DB.MultiSegmentGrid.Create Method

**中文**: 创建、新建、生成、建立、新增

Create a MultiSegmentGrid element from the specified curve loop.

## Syntax (C#)
```csharp
public static ElementId Create(
	Document document,
	ElementId typeId,
	CurveLoop curveLoop,
	ElementId sketchPlaneId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to create the MultiSegmentGrid.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - Element id of a GridType element.
- **curveLoop** (`Autodesk.Revit.DB.CurveLoop`) - An open curve loop consisting of lines and arcs.
- **sketchPlaneId** (`Autodesk.Revit.DB.ElementId`) - Element id of a SketchPlane for the curves elements that will be created from the curveLoop.

## Returns
The element id of the new MultiSegmentGrid element.

## Remarks
For each curve in the curve loop, a corresponding Grid will be created.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element id should refer to a valid horizontal SketchPlane.
 -or-
 The element id should refer to a GridType element.
 -or-
 The curve loop should be an open loop consisting of lines and arcs.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

