---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetAdjacentRegions(System.Int32)
source: html/2749034b-a043-be0a-7400-1cdbbef24c76.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetAdjacentRegions Method

Gets the ids of region bound to a specified segment.

## Syntax (C#)
```csharp
public IList<int> GetAdjacentRegions(
	int segmentId
)
```

## Parameters
- **segmentId** (`System.Int32`) - The id of a segment in this CompoundStructure.

## Returns
The ids of the regions that are bounded by the specified segment.

## Remarks
The boundaries of the regions of a vertically compound structure consist of vertical
 horizontal segments with unique ids.
 The segments which define the outer boundary of the structure are adjacent to one region,
 other segments will be adjacent to two regions.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The segment id is invalid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is valid only for vertically compound structures.

