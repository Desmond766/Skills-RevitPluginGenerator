---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.AddListeningDimensionSegmentToBend(Autodesk.Revit.DB.ElementId,System.Double,System.Double,System.Int32,System.Int32,System.Int32)
source: html/4696bd5b-9eca-44f2-9978-5f6d4c4fd563.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.AddListeningDimensionSegmentToBend Method

Specify a dimension perpendicular to one fixed-direction segment,
 referring to that segment and some other bend in the shape,
 measured by a read-only parameter.

## Syntax (C#)
```csharp
public void AddListeningDimensionSegmentToBend(
	ElementId paramId,
	double constraintDirCoordX,
	double constraintDirCoordY,
	int iSegment0,
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
- **iSegment1** (`System.Int32`) - Index of the second segment (0 to NumberOfSegments - 1).
- **iEnd1** (`System.Int32`) - End (0 or 1) of the second segment.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId is not the id of a shared parameter in the current document,
 or its unit type is not UT_Reinforcement_Length or UT_Angle.
 -or-
 The length of the vector (constraintDirCoordX, constraintDirCoordY) is too close to zero.
 -or-
 iSegment0 is not between 0 and NumberOfSegments.
 -or-
 Edge iSegment0 has a variable angle; it must have a fixed angle perpendicular to (constraintDirCoordX, constraintDirCoordY).
 -or-
 iSegment1 is not between 0 and NumberOfSegments.
 -or-
 iEnd1 is neither 0 nor 1.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

