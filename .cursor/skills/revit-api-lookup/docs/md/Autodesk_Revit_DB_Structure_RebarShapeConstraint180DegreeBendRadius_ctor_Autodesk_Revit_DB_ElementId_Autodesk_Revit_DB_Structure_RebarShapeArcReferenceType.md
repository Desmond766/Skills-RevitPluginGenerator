---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeConstraint180DegreeBendRadius.#ctor(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Structure.RebarShapeArcReferenceType)
source: html/54570ecc-86ef-89b5-1952-9b82c7055733.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeConstraint180DegreeBendRadius.#ctor Method

Create a 180-degree bend constraint driven by radius.

## Syntax (C#)
```csharp
public RebarShapeConstraint180DegreeBendRadius(
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

