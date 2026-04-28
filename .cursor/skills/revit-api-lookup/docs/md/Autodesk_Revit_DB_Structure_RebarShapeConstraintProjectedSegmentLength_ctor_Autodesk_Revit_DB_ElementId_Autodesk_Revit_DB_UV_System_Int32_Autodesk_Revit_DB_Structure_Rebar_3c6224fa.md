---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeConstraintProjectedSegmentLength.#ctor(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.UV,System.Int32,Autodesk.Revit.DB.Structure.RebarShapeSegmentEndReferenceType,Autodesk.Revit.DB.Structure.RebarShapeSegmentEndReferenceType)
source: html/99ce7f5e-aa7d-479c-db28-ac76699f5c72.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeConstraintProjectedSegmentLength.#ctor Method

Constructs a new instance of a RebarConstraintProjectEdgedLength object using a shape
 parameter, direction, and reference types.

## Syntax (C#)
```csharp
public RebarShapeConstraintProjectedSegmentLength(
	ElementId paramId,
	UV direction,
	int tripleProductSign,
	RebarShapeSegmentEndReferenceType refType0,
	RebarShapeSegmentEndReferenceType refType1
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - The Id of a Rebar Shape parameter.
- **direction** (`Autodesk.Revit.DB.UV`) - A vector specifying the direction of the constraint. The direction is fixed,
 and the shape is always constructed so that the segment's
 direction has a positive dot product with this vector.
- **tripleProductSign** (`System.Int32`) - Sign of the z-coordinate of the cross
 product of the "direction" argument with the segment vector. In other words,
 1 if the segment direction is to be on the left of the constraint direction,
 or -1 if the segment direction is to be on the right.
- **refType0** (`Autodesk.Revit.DB.Structure.RebarShapeSegmentEndReferenceType`) - Choose between two possibilities for the first reference of the length constraint.
- **refType1** (`Autodesk.Revit.DB.Structure.RebarShapeSegmentEndReferenceType`) - Choose between two possibilities for the second reference of the length constraint.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId is not a valid Element identifier.
 -or-
 tripleProductSign is not 1 or -1.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - direction has zero length.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration

