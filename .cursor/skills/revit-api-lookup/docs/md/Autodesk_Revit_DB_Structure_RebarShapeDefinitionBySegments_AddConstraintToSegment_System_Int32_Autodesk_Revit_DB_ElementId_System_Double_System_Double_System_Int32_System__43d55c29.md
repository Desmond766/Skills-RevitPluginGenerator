---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.AddConstraintToSegment(System.Int32,Autodesk.Revit.DB.ElementId,System.Double,System.Double,System.Int32,System.Boolean,System.Boolean)
source: html/ffaca4d8-ddb4-c21e-7830-b5fffe314fc8.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.AddConstraintToSegment Method

Add a constraint that helps determine the length of a segment.

## Syntax (C#)
```csharp
public void AddConstraintToSegment(
	int iSegment,
	ElementId paramId,
	double constraintDirCoordX,
	double constraintDirCoordY,
	int signOfZCoordOfCrossProductOfConstraintDirBySegmentDir,
	bool measureToOutsideOfBend0,
	bool measureToOutsideOfBend1
)
```

## Parameters
- **iSegment** (`System.Int32`) - Index of the segment (0 to NumberOfSegments - 1).
- **paramId** (`Autodesk.Revit.DB.ElementId`) - Id of a parameter to drive the constraint.
 To obtain the id of a shared parameter,
 call RebarShape.GetElementIdForExternalDefinition().
- **constraintDirCoordX** (`System.Double`) - The x-coordinate of a 2D vector specifying the constraint direction.
- **constraintDirCoordY** (`System.Double`) - The y-coordinate of a 2D vector specifying the constraint direction.
- **signOfZCoordOfCrossProductOfConstraintDirBySegmentDir** (`System.Int32`) - Legal values are 1 and -1. For a fixed-direction segment, this value is ignored. For a variable-direction segment, this value is combined with the constraint length (the nonnegative value associated with 'param') to determine the direction of the segment. For example, a segment whose direction vector lies in the upper-right quadrant of the plane, and whose x-axis projected length is A and whose y-axis projected length is B, could be created by calling: AddConstraintToSegment(iSegment, paramA, 1.0, 0.0, 1, ...) AddConstraintToSegment(iSegment, paramB, 0.0, 1.0, -1, ...)
- **measureToOutsideOfBend0** (`System.Boolean`) - Choose between two possibilities for the first reference of the length dimension. If false, the reference is at the point where the bend begins; equivalently, at the projection of the bend centerpoint onto the segment. If true, the reference is moved outward by a distance equal to the bend radius plus the bar diameter; if the bend is a right angle or greater, this is equivalent to putting the reference at the outer face of the bend.
- **measureToOutsideOfBend1** (`System.Boolean`) - Choose between two possibilities for the second reference of the length dimension.

## Remarks
The vector defined by (constraintDirCoordX, constraintDirCoordY) must have a positive dot product with the desired direction of the segment. This restriction, combined with the value of signOfZCoordOfCrossProductOfConstraintDirBySegmentDir, defines a quadrant of the plane that limits the variable-angle segment.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - iSegment is not between 0 and NumberOfSegments.
 -or-
 paramId is not the id of a shared parameter in the current document,
 or its unit type is not UT_Reinforcement_Length or UT_Angle.
 -or-
 The length of the vector (constraintDirCoordX, constraintDirCoordY) is too close to zero.
 -or-
 signOfZCoordOfCrossProductOfConstraintDirBySegmentDir is neither -1 nor 1.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

