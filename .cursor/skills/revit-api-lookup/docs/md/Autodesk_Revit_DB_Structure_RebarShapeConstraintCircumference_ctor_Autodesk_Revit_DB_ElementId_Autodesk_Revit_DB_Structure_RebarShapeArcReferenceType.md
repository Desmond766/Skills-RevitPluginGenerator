---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeConstraintCircumference.#ctor(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Structure.RebarShapeArcReferenceType)
source: html/dd748e8c-0fa7-539e-2f25-914a0e9deeb2.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeConstraintCircumference.#ctor Method

Create a circumference constraint.

## Syntax (C#)
```csharp
public RebarShapeConstraintCircumference(
	ElementId paramId,
	RebarShapeArcReferenceType refType
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - The Id of a Rebar Shape parameter.
- **refType** (`Autodesk.Revit.DB.Structure.RebarShapeArcReferenceType`) - A choice of rule for measuring the circumference.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId is not a valid Element identifier.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

