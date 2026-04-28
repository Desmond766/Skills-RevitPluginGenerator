---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.AddListeningDimensionBendToBend(Autodesk.Revit.DB.ElementId,System.Double,System.Double,System.Int32,System.Int32,System.Int32,System.Int32)
source: html/4b140fb2-df81-856d-8188-6630c5be2006.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.AddListeningDimensionBendToBend Method

Specify a dimension between two bends, measured by a read-only parameter.

## Syntax (C#)
```csharp
public void AddListeningDimensionBendToBend(
	ElementId paramId,
	double constraintDirCoordX,
	double constraintDirCoordY,
	int iSegment0,
	int iEnd0,
	int iSegment1,
	int iEnd1
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - Id of a parameter to report the length of the dimension. The parameter will be read-only
 on Rebar instances.
- **constraintDirCoordX** (`System.Double`) - The x-coordinate of a 2D vector specifying the constraint direction.
- **constraintDirCoordY** (`System.Double`) - The y-coordinate of a 2D vector specifying the constraint direction.
- **iSegment0** (`System.Int32`) - Index of the first segment (0 to NumberOfSegments - 1).
- **iEnd0** (`System.Int32`) - End (0 or 1) of the first segment.
- **iSegment1** (`System.Int32`) - Index of the second segment (0 to NumberOfSegments - 1).
- **iEnd1** (`System.Int32`) - End (0 or 1) of the second segment.

## Remarks
Each reference is at the outside of the bend, perpendicular to the specified segment. So the overall length of a shape with 5 segments might be defined by calling this function with iSegment0=0, iEnd0=0, iSegment1=4, iEnd1=1.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId is not the id of a shared parameter in the current document,
 or its unit type is not UT_Reinforcement_Length or UT_Angle.
 -or-
 The length of the vector (constraintDirCoordX, constraintDirCoordY) is too close to zero.
 -or-
 iSegment0 is not between 0 and NumberOfSegments.
 -or-
 iEnd0 is neither 0 nor 1.
 -or-
 iSegment1 is not between 0 and NumberOfSegments.
 -or-
 iEnd1 is neither 0 nor 1.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

