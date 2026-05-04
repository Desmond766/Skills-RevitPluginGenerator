---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.FindEnclosingRegionAndSegments(Autodesk.Revit.DB.UV,Autodesk.Revit.DB.RectangularGridSegmentOrientation,System.Int32@,System.Int32@)
source: html/e5a63d60-6fa3-f414-20b5-ef72da637849.htm
---
# Autodesk.Revit.DB.CompoundStructure.FindEnclosingRegionAndSegments Method

Given a pair of grid coordinates, and a direction for splitting, returns the enclosing region and the two segments
 intersected by a line through the grid point.

## Syntax (C#)
```csharp
public int FindEnclosingRegionAndSegments(
	UV gridUV,
	RectangularGridSegmentOrientation splitDirection,
	out int segmentId1,
	out int segmentId2
)
```

## Parameters
- **gridUV** (`Autodesk.Revit.DB.UV`) - Coordinates of a point in the rectangular grid of this compound structure.
- **splitDirection** (`Autodesk.Revit.DB.RectangularGridSegmentOrientation`) - Specifies the direction of the split.
- **segmentId1** (`System.Int32 %`) - The id of a segment in the boundary of the containing region which is split by a line through gridUV in the specified direction.
- **segmentId2** (`System.Int32 %`) - The id of a segment in the boundary of the containing region which is split by a line through gridUV in the specified direction.

## Returns
Returns the id of the enclosing region, and -1 if no region encloses the point.

## Remarks
Grid coordinates correspond to uv coordinates of faces.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is valid only for vertically compound structures.

