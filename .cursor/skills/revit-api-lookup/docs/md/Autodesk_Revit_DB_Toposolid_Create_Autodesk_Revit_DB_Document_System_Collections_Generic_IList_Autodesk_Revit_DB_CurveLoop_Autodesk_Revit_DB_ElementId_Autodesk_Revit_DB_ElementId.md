---
kind: method
id: M:Autodesk.Revit.DB.Toposolid.Create(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop},Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/35fc44fe-c86f-6963-c2b2-e6290288c748.htm
---
# Autodesk.Revit.DB.Toposolid.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of toposolid within the project.

## Syntax (C#)
```csharp
public static Toposolid Create(
	Document document,
	IList<CurveLoop> profiles,
	ElementId topoTypeId,
	ElementId levelId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the new toposolid is created.
- **profiles** (`System.Collections.Generic.IList < CurveLoop >`) - An array of planar curve loops that represent the profiles of the toposolid.
- **topoTypeId** (`Autodesk.Revit.DB.ElementId`) - Id of the toposolid type to be used by the new toposolid.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - Id of the level on which the toposolid is to be placed.

## Returns
A new toposolid object within the project if successful.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input curve loops cannot compose a valid boundary, that means:
 the "curveLoops" collection is empty;
 or some curve loops intersect with each other;
 or each curve loop is not closed individually;
 or each curve loop is not planar;
 or each curve loop is not in a plane parallel to the horizontal(XY) plane;
 or input curves contain at least one helical curve.
 -or-
 The ElementId levelId is not a Level.
 -or-
 Toposolid type is not valid for this toposolid.
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

