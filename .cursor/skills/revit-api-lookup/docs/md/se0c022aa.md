---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeSegment.SetConstraints(System.Collections.Generic.IList{Autodesk.Revit.DB.Structure.RebarShapeConstraint})
source: html/679b4a55-6526-089f-88cc-9d7637941310.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeSegment.SetConstraints Method

Assign a new list of constraints to this segment.

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
 RebarShapeConstraintAngleFromFixedDir RebarShapeConstraintSegmentLength RebarShapeConstraintFixedSegmentDir RebarShapeConstraintProjectedSegmentLength RebarShapeConstraint180DegreeBendArcLength RebarShapeConstraint180DegreeBendRadius RebarShapeConstraint180DegreeDefaultBend 
 At least two independent constraints must be specified. Overconstraining
 is supported. Constraints of type RebarShapeConstraintFixedSegmentDir must be unique.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more of the constraints is of a type not supported for RebarShapeSegment.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

