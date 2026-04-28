---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.SetSegmentFixedDirection(System.Int32,System.Double,System.Double)
source: html/888953d2-b8b6-acab-b5e1-9ee2e1a5952e.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.SetSegmentFixedDirection Method

Fix the direction of a segment.

## Syntax (C#)
```csharp
public void SetSegmentFixedDirection(
	int iSegment,
	double vecCoordX,
	double vecCoordY
)
```

## Parameters
- **iSegment** (`System.Int32`) - Index of the segment (0 to NumberOfSegments - 1).
- **vecCoordX** (`System.Double`) - The x-coordinate of a 2D vector specifying the segment direction.
- **vecCoordY** (`System.Double`) - The y-coordinate of a 2D vector specifying the segment direction.

## Remarks
The centerline of the segment will be constrained to be parallel to the vector. The segment must have at least one constraint.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - iSegment is not between 0 and NumberOfSegments.
 -or-
 The length of the vector (vecCoordX, vecCoordY) is too close to zero.

