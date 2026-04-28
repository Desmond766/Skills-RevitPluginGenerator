---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionByArc.AddConstraintRadius(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Structure.RebarShapeArcReferenceType)
source: html/c952aa14-83ea-a21b-6262-fd5128a399a3.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionByArc.AddConstraintRadius Method

Specify a parameter to drive the radius of the shape.

## Syntax (C#)
```csharp
public void AddConstraintRadius(
	ElementId paramId,
	RebarShapeArcReferenceType arcRefType
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - Id of a parameter to drive the constraint.
 To obtain the id of a shared parameter,
 call RebarShape.GetElementIdForExternalDefinition().
- **arcRefType** (`Autodesk.Revit.DB.Structure.RebarShapeArcReferenceType`) - Specify how the radius should be measured--to the interior of the bend, the centerline of the bar, or the exterior.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

