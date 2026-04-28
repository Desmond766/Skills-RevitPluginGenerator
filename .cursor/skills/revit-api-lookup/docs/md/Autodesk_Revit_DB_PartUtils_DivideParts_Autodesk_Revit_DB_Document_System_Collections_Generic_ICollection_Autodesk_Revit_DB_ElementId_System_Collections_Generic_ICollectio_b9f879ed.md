---
kind: method
id: M:Autodesk.Revit.DB.PartUtils.DivideParts(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},System.Collections.Generic.IList{Autodesk.Revit.DB.Curve},Autodesk.Revit.DB.ElementId)
source: html/45950f87-1cd6-fdfa-5167-1f42fb7b2c6b.htm
---
# Autodesk.Revit.DB.PartUtils.DivideParts Method

Creates divided parts out of parts.

## Syntax (C#)
```csharp
public static PartMaker DivideParts(
	Document document,
	ICollection<ElementId> elementIdsToDivide,
	ICollection<ElementId> intersectingReferenceIds,
	IList<Curve> curveArray,
	ElementId sketchPlaneId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the parts.
- **elementIdsToDivide** (`System.Collections.Generic.ICollection < ElementId >`) - The elements that will be divided.
- **intersectingReferenceIds** (`System.Collections.Generic.ICollection < ElementId >`) - Intersecting references that will divide the elements.
- **curveArray** (`System.Collections.Generic.IList < Curve >`) - Array of curves that will divide the elements.
- **sketchPlaneId** (`Autodesk.Revit.DB.ElementId`) - SketchPlane id for the curves that divide the elements.

## Returns
The newly created PartMaker. Nothing nullptr a null reference ( Nothing in Visual Basic) if no parts are divided.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more element ids was not permitted for dividing parts.
 Elements should be parts that are not yet divided and maximum distance from an original has not yet been reached.
 -or-
 One or more element ids was not permitted as intersecting references.
 Intersecting references should be levels, grids, or reference planes.
 -or-
 The element id should refer to a valid SketchPlane.
 -or-
 The input curveArray contains at least one helical curve and is not supported for this operation.
 -or-
 The input curveArray contains at least one NULL pointer and is not supported for this operation.
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

