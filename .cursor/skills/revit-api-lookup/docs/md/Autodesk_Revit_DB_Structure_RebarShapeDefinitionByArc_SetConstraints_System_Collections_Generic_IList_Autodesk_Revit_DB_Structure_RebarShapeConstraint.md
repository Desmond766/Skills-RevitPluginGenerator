---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionByArc.SetConstraints(System.Collections.Generic.IList{Autodesk.Revit.DB.Structure.RebarShapeConstraint})
source: html/250412ee-3cf3-ccba-0cf6-3ee991ac4221.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionByArc.SetConstraints Method

Assign a new list of constraints to this definition.

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
 with AddParameter().
If the Type is Arc or LappedCircle, the allowable constraint types are:
 RebarShapeConstraintArcLength RebarShapeConstraintRadius RebarShapeConstraintDiameter RebarShapeConstraintCircumference RebarShapeConstraintSagittaLength RebarShapeConstraintChordLength 
 At least two independent constraints must be specified. Overconstraining
 is supported.
If the Type is Spiral, the allowable constraints are:
 RebarShapeConstraintRadius RebarShapeConstraintDiameter RebarShapeConstraintCircumference 
 At least one constraint must be specified.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more of the constraints is of a type not supported for this definition.
 -or-
 One or more of the constraints refers to a parameter that has not been added yet.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

