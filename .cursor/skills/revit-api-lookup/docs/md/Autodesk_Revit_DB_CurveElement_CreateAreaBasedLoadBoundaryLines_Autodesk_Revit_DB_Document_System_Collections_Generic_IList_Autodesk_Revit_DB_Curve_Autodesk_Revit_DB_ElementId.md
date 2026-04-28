---
kind: method
id: M:Autodesk.Revit.DB.CurveElement.CreateAreaBasedLoadBoundaryLines(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.Curve},Autodesk.Revit.DB.ElementId)
source: html/aee4c63d-0894-39d4-560f-971bd29bf948.htm
---
# Autodesk.Revit.DB.CurveElement.CreateAreaBasedLoadBoundaryLines Method

Creates area based load boundary lines.

## Syntax (C#)
```csharp
public static IList<CurveElement> CreateAreaBasedLoadBoundaryLines(
	Document document,
	IList<Curve> curves,
	ElementId levelId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to create the area based load boundary lines.
- **curves** (`System.Collections.Generic.IList < Curve >`) - The curves.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The id of level.

## Returns
The newly created area based load boundary lines.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 The input curves contains a null pointer or a curve that is not bounded.
 -or-
 The input curves contains at least one curve which is degenerate (its length is too close to zero).
 -or-
 The ElementId levelId is not a Level.
 -or-
 The input curves contains a curve doesn't lie in the plane of the level.
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

