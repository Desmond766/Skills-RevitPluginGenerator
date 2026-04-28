---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeConstraintSegmentLength.#ctor(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Structure.RebarShapeSegmentEndReferenceType,Autodesk.Revit.DB.Structure.RebarShapeSegmentEndReferenceType)
source: html/dd7ef8cf-31c4-5043-5f85-f4b03c224595.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeConstraintSegmentLength.#ctor Method

Create a segment length constraint.

## Syntax (C#)
```csharp
public RebarShapeConstraintSegmentLength(
	ElementId paramId,
	RebarShapeSegmentEndReferenceType refType0,
	RebarShapeSegmentEndReferenceType refType1
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - The Id of a Rebar Shape parameter.
- **refType0** (`Autodesk.Revit.DB.Structure.RebarShapeSegmentEndReferenceType`) - Choose between two possibilities for the first reference of the length constraint.
- **refType1** (`Autodesk.Revit.DB.Structure.RebarShapeSegmentEndReferenceType`) - Choose between two possibilities for the second reference of the length constraint.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId is not a valid Element identifier.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

