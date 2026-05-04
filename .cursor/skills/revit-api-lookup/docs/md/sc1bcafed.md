---
kind: method
id: M:Autodesk.Revit.DB.BeamSystem.Create(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.Curve},Autodesk.Revit.DB.Level,Autodesk.Revit.DB.XYZ,System.Boolean)
zh: 创建、新建、生成、建立、新增
source: html/03e84698-d122-594b-b436-4932f9ff49c6.htm
---
# Autodesk.Revit.DB.BeamSystem.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new BeamSystem with specified profile curves.

## Syntax (C#)
```csharp
public static BeamSystem Create(
	Document document,
	IList<Curve> profile,
	Level level,
	XYZ direction,
	bool is3d
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the new BeamSystem is created.
- **profile** (`System.Collections.Generic.IList < Curve >`) - The profile of the BeamSystem.
- **level** (`Autodesk.Revit.DB.Level`) - The level on which the BeamSystem is to be created.
 The work-plane of the BeamSystem will be the sketch plane associated with the Level.
 If there is no current sketch plane associated with the level yet, we will create a default one.
- **direction** (`Autodesk.Revit.DB.XYZ`) - The direction is the direction of the BeamSystem.
- **is3d** (`System.Boolean`) - Whether the BeamSystem is 3D. If the BeamSystem is 3D, the sketchPlane must be a level, otherwise an exception will be thrown.

## Returns
If successful, a new BeamSystem object will be returned.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input profile contains at least one helical curve and is not supported for this operation.
 -or-
 The input level does not have associated plan view.
 -or-
 The plan view associated with the input level is not valid.
 -or-
 Can not get valid sketch plane from the input level.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

