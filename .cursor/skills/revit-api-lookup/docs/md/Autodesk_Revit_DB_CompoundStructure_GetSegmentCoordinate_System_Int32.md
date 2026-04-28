---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetSegmentCoordinate(System.Int32)
source: html/d729ba6f-a98f-98b3-43f9-60f63fbd834b.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetSegmentCoordinate Method

Gets the coordinate of a segment.

## Syntax (C#)
```csharp
public double GetSegmentCoordinate(
	int segmentId
)
```

## Parameters
- **segmentId** (`System.Int32`) - The id of a segment in this CompoundStructure.

## Returns
The local coordinates of the specified segment.

## Remarks
The boundaries of the regions of a vertically compound structure consist of vertical
 horizontal segments.
 If the segment orientation is horizontal, then its coordinate will lie in the range [0.0, SampleHeight].
 If the segment orientation is vertical, then its coordinate will lie in the range of u values obtained from
 GetRegionEnvelope(Int32) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The segment id is invalid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is valid only for vertically compound structures.

