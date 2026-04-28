---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeConstraintDiameter.#ctor(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Structure.RebarShapeArcReferenceType)
source: html/285b1229-2138-871f-206e-8151cdcb2a4d.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeConstraintDiameter.#ctor Method

Create a diameter constraint.

## Syntax (C#)
```csharp
public RebarShapeConstraintDiameter(
	ElementId paramId,
	RebarShapeArcReferenceType refType
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - The Id of a Rebar Shape parameter.
- **refType** (`Autodesk.Revit.DB.Structure.RebarShapeArcReferenceType`) - A choice of rule for measuring the diameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId is not a valid Element identifier.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

