---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionByArc.AddConstraintArcLength(Autodesk.Revit.DB.ElementId)
source: html/61df5a7c-d82f-88f7-318c-ed602b8ba3b1.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionByArc.AddConstraintArcLength Method

Specify a parameter to drive the arc length of the shape.

## Syntax (C#)
```csharp
public void AddConstraintArcLength(
	ElementId paramId
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - Id of a parameter to drive the constraint.
 To obtain the id of a shared parameter,
 call RebarShape.GetElementIdForExternalDefinition().

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

