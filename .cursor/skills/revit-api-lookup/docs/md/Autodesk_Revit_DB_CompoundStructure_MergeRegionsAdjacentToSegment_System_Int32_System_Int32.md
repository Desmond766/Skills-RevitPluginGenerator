---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.MergeRegionsAdjacentToSegment(System.Int32,System.Int32)
source: html/ebc23bae-07f1-b48c-8cfa-dcb8850cb723.htm
---
# Autodesk.Revit.DB.CompoundStructure.MergeRegionsAdjacentToSegment Method

Merges the two regions which share the specified segment.

## Syntax (C#)
```csharp
public int MergeRegionsAdjacentToSegment(
	int segmentId,
	int layerIdxForMergedRegion
)
```

## Parameters
- **segmentId** (`System.Int32`) - The id of a segment in the underlying grid.
- **layerIdxForMergedRegion** (`System.Int32`) - The index of the layer to which the resulting region will be associated.

## Returns
The id of the resulting region. If -1 is returned, then the operation would have produced
 an invalid region and was not performed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The layer index is out of range.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Split and merge regions operations can be used only for vertically compound structures without variable thickness layers.
 -or-
 The segment is not shared by adjacent regions.

