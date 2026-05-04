---
kind: method
id: M:Autodesk.Revit.DB.CurveElement.CreateAreaBasedLoadBoundaryLine(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Curve,Autodesk.Revit.DB.ElementId)
source: html/71384e53-8fc6-faad-b0fa-616f3d692f34.htm
---
# Autodesk.Revit.DB.CurveElement.CreateAreaBasedLoadBoundaryLine Method

Creates an area based load boundary line.

## Syntax (C#)
```csharp
public static CurveElement CreateAreaBasedLoadBoundaryLine(
	Document document,
	Curve curve,
	ElementId levelId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to create the area based load boundary line.
- **curve** (`Autodesk.Revit.DB.Curve`) - The curve.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The id of level.

## Returns
The newly created area based load boundary line.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 The input curve is not bound.
 -or-
 The curve is degenerate (its length is too close to zero).
 -or-
 The ElementId levelId is not a Level.
 -or-
 The curve doesn't lie in the plane of the level.
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

