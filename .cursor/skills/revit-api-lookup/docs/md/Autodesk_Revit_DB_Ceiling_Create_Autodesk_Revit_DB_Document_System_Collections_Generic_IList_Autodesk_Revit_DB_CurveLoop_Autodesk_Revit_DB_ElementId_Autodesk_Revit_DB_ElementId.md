---
kind: method
id: M:Autodesk.Revit.DB.Ceiling.Create(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop},Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/63030aa3-d58d-b830-db18-0882c5990507.htm
---
# Autodesk.Revit.DB.Ceiling.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of ceiling within the project.

## Syntax (C#)
```csharp
public static Ceiling Create(
	Document document,
	IList<CurveLoop> curveLoops,
	ElementId ceilingTypeId,
	ElementId levelId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the new ceiling is created.
- **curveLoops** (`System.Collections.Generic.IList < CurveLoop >`) - An array of planar curve loops that represent the profile of the ceiling.
- **ceilingTypeId** (`Autodesk.Revit.DB.ElementId`) - Id of the ceiling type to be used by the new ceiling. If InvalidElementId is passed, the default type will be used.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - Id of the level on which the ceiling is to be placed.

## Returns
If successful a new ceiling object within the project.

## Remarks
To validate curve loop profile use BoundaryValidation .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId levelId is not a Level.
 -or-
 The ElementId ceilingTypeId does not correspond to a CeilingType.
 -or-
 The input curve loops cannot compose a valid boundary, that means:
 the "curveLoops" collection is empty;
 or some curve loops intersect with each other;
 or each curve loop is not closed individually;
 or each curve loop is not planar;
 or each curve loop is not in a plane parallel to the horizontal(XY) plane;
 or input curves contain at least one helical curve.
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

