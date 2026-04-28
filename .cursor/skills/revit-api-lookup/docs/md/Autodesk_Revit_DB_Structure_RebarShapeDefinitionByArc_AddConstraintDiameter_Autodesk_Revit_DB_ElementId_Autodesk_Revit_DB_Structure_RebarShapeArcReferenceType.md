---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionByArc.AddConstraintDiameter(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Structure.RebarShapeArcReferenceType)
source: html/d493f0bc-6df5-0304-7dc0-180084d3b434.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionByArc.AddConstraintDiameter Method

Specify a parameter to drive the diameter of the shape.

## Syntax (C#)
```csharp
public void AddConstraintDiameter(
	ElementId paramId,
	RebarShapeArcReferenceType arcRefType
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - Id of a parameter to drive the constraint.
 To obtain the id of a shared parameter,
 call RebarShape.GetElementIdForExternalDefinition().
- **arcRefType** (`Autodesk.Revit.DB.Structure.RebarShapeArcReferenceType`) - Specify how the diameter should be measured--to the interior of the bend, the centerline of the bar, or the exterior.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

