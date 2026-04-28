---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeVertex.SetConstraints(System.Collections.Generic.IList{Autodesk.Revit.DB.Structure.RebarShapeConstraint})
source: html/f2dc51f3-19af-6a95-6e93-d8717c6a5d05.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeVertex.SetConstraints Method

Assign a new list of constraints to this vertex.

## Syntax (C#)
```csharp
public void SetConstraints(
	IList<RebarShapeConstraint> constraints
)
```

## Parameters
- **constraints** (`System.Collections.Generic.IList < RebarShapeConstraint >`) - A new list of constraints.

## Remarks
Any existing constraints are discarded. The new constraints replace them.
 Any parameters driving the constraints must already be added
 with RebarShapeDefinition.AddParameter().
The allowable constraint types are:
 RebarShapeConstraintRadius RebarShapeConstraintArcLength 
 Any number of constraints may be specified. With no constraints,
 the bend radius will default to the appropriate bend radius
 from the RebarBarType element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more of the constraints is of a type not supported for RebarShapeVertex.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

