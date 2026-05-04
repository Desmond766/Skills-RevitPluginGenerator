---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.AddListeningDimensionSegmentToSegment(Autodesk.Revit.DB.ElementId,System.Double,System.Double,System.Int32,System.Int32)
source: html/6a85387a-f0f5-ed76-6cf6-bc1f5f309977.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.AddListeningDimensionSegmentToSegment Method

Specify a dimension perpendicular to two fixed-direction segments, measured by a read-only parameter.

## Syntax (C#)
```csharp
public void AddListeningDimensionSegmentToSegment(
	ElementId paramId,
	double constraintDirCoordX,
	double constraintDirCoordY,
	int iSegment0,
	int iSegment1
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - Id of a parameter to report the length of the dimension. The parameter will be read-only
 on Rebar instances.
- **constraintDirCoordX** (`System.Double`) - The x-coordinate of a 2D vector specifying the constraint direction.
- **constraintDirCoordY** (`System.Double`) - The y-coordinate of a 2D vector specifying the constraint direction.
- **iSegment0** (`System.Int32`) - Index of the first segment (0 to NumberOfSegments - 1).
- **iSegment1** (`System.Int32`) - Index of the second segment (0 to NumberOfSegments - 1).

## Remarks
RebarShapeDefinitionBySegments supports driving (read-write) dimensions only when they are associated with a single segment. Non-driving dimensions can involve multiple segments.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId is not the id of a shared parameter in the current document,
 or its unit type is not UT_Reinforcement_Length or UT_Angle.
 -or-
 The length of the vector (constraintDirCoordX, constraintDirCoordY) is too close to zero.
 -or-
 iSegment0 is not between 0 and NumberOfSegments.
 -or-
 iSegment1 is not between 0 and NumberOfSegments.
 -or-
 Edge iSegment0 has a variable angle; it must have a fixed angle perpendicular to (constraintDirCoordX, constraintDirCoordY).
 -or-
 Edge iSegment1 has a variable angle; it must have a fixed angle perpendicular to (constraintDirCoordX, constraintDirCoordY).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

