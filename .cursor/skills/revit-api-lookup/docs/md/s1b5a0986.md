---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeConstraintRadius.#ctor(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Structure.RebarShapeArcReferenceType)
source: html/286a1454-b07d-df71-c86c-bd9389fe4c39.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeConstraintRadius.#ctor Method

Create a radius constraint.

## Syntax (C#)
```csharp
public RebarShapeConstraintRadius(
	ElementId paramId,
	RebarShapeArcReferenceType refType
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - The Id of a Rebar Shape parameter.
- **refType** (`Autodesk.Revit.DB.Structure.RebarShapeArcReferenceType`) - A choice of rule for measuring the radius.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId is not a valid Element identifier.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

