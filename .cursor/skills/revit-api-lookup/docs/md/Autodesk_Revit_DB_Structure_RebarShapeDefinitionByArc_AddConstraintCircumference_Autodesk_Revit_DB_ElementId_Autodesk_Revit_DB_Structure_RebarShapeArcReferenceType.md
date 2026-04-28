---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionByArc.AddConstraintCircumference(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Structure.RebarShapeArcReferenceType)
source: html/962fe913-b744-09cd-2f0e-adcac46376c7.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionByArc.AddConstraintCircumference Method

Specify a parameter to drive the circumference of the shape.

## Syntax (C#)
```csharp
public void AddConstraintCircumference(
	ElementId paramId,
	RebarShapeArcReferenceType arcRefType
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - Id of a parameter to drive the constraint.
 To obtain the id of a shared parameter,
 call RebarShape.GetElementIdForExternalDefinition().
- **arcRefType** (`Autodesk.Revit.DB.Structure.RebarShapeArcReferenceType`) - Specify along which circle the circumference is measured--to the interior
 of the bar, the centerline, or the exterior.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

