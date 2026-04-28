---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.SplitRegion(Autodesk.Revit.DB.UV,Autodesk.Revit.DB.RectangularGridSegmentOrientation)
source: html/8db1791b-4b60-6edb-81bf-908a673b3baa.htm
---
# Autodesk.Revit.DB.CompoundStructure.SplitRegion Method

Splits the region which contains the specified grid point by a line with the specified direction.

## Syntax (C#)
```csharp
public int SplitRegion(
	UV gridUV,
	RectangularGridSegmentOrientation splitDirection
)
```

## Parameters
- **gridUV** (`Autodesk.Revit.DB.UV`) - Coordinates of a point in the rectangular grid of this compound structure.
- **splitDirection** (`Autodesk.Revit.DB.RectangularGridSegmentOrientation`) - Specifies the direction of the split.

## Returns
The id of the region created by this operation.

## Remarks
This method is meant to be used in conjunction with FindEnclosingRegionAndSegments(UV, RectangularGridSegmentOrientation, Int32 , Int32 ) .
 Grid coordinates correspond to uv coordinates of faces.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Split and merge regions operations can be used only for vertically compound structures without variable thickness layers.

