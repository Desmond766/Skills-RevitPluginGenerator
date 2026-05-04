---
kind: method
id: M:Autodesk.Revit.DB.Floor.Create(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop},Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,System.Boolean,Autodesk.Revit.DB.Line,System.Double)
zh: 创建、新建、生成、建立、新增
source: html/0013a9e5-a9c4-bb2c-f29d-aa4b732b815a.htm
---
# Autodesk.Revit.DB.Floor.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of floor within the project.

## Syntax (C#)
```csharp
public static Floor Create(
	Document document,
	IList<CurveLoop> profile,
	ElementId floorTypeId,
	ElementId levelId,
	bool isStructural,
	Line slopeArrow,
	double slope
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the new floor is created.
- **profile** (`System.Collections.Generic.IList < CurveLoop >`) - An array of planar curve loops that represent the profile of the floor.
- **floorTypeId** (`Autodesk.Revit.DB.ElementId`) - Id of the floor type to be used by the new Floor.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - Id of the level on which the floor is to be placed.
- **isStructural** (`System.Boolean`) - True if new floor should be structural, false if architectural.
- **slopeArrow** (`Autodesk.Revit.DB.Line`) - A line used to control the slope angle of the Floor. It must be horizontal.
 If slopeArrow is Nothing nullptr a null reference ( Nothing in Visual Basic) , the horizontal floor will be created.
- **slope** (`System.Double`) - The slope angle. If slopeArrow is Nothing nullptr a null reference ( Nothing in Visual Basic) , this parameter will be ignored.

## Returns
If successful a new floor object within the project.

## Remarks
To validate curve loop profile use BoundaryValidation .
 To get default floor type use GetDefaultFloorType(Document, Boolean) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId levelId is not a Level.
 -or-
 The floorTypeId does not correspond to a FloorType.
 -or-
 The input curve loops cannot compose a valid boundary, that means:
 the "curveLoops" collection is empty;
 or some curve loops intersect with each other;
 or each curve loop is not closed individually;
 or each curve loop is not planar;
 or each curve loop is not in a plane parallel to the horizontal(XY) plane;
 or input curves contain at least one helical curve.
 -or-
 The slopeArrow must be a horizontal line.
 -or-
 Input curves build invalid sketch.
 -or-
 Failed to create curve elements.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Cannot generate a sketch.
 -or-
 Failed to create new element.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

