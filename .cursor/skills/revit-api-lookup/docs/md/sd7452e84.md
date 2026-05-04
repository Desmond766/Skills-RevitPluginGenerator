---
kind: method
id: M:Autodesk.Revit.DB.BeamSystem.Create(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.Curve},Autodesk.Revit.DB.SketchPlane,System.Int32)
zh: 创建、新建、生成、建立、新增
source: html/320f188f-5b0e-e34f-0dc1-c652029be9ae.htm
---
# Autodesk.Revit.DB.BeamSystem.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a 2D BeamSystem with specified profile curves.

## Syntax (C#)
```csharp
public static BeamSystem Create(
	Document document,
	IList<Curve> profile,
	SketchPlane sketchPlane,
	int curveIndexForDirection
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the new BeamSystem is created.
- **profile** (`System.Collections.Generic.IList < Curve >`) - The profile of the BeamSystem.
- **sketchPlane** (`Autodesk.Revit.DB.SketchPlane`) - The work-plane for the BeamSystem.
- **curveIndexForDirection** (`System.Int32`) - Index of the curve in the profile to be used as direction.
 '0' means the default direction-to use the first curve in profile.
 The curve from the profile to be used as direction must be a Line.

## Returns
If successful, a new BeamSystem object will be returned.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - SketchPlane is not valid for BeamSystem creation.
 -or-
 The input profile contains at least one helical curve and is not supported for this operation.
 -or-
 The profile curves must be in the sketch plane.
 -or-
 The curve index must be valid and the curve to be used as direction must be a Line.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

