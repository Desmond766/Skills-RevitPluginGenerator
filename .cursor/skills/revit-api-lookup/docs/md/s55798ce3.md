---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.CanLayerWidthBeNonZero(System.Int32)
source: html/cae97272-2e0d-cee9-519d-9a983dd05de1.htm
---
# Autodesk.Revit.DB.CompoundStructure.CanLayerWidthBeNonZero Method

Identifies if changing the width of an existing layer from zero to a positive value will create a rectangular region.

## Syntax (C#)
```csharp
public bool CanLayerWidthBeNonZero(
	int layerIdx
)
```

## Parameters
- **layerIdx** (`System.Int32`) - The index of a CompoundStructureLayer.

## Remarks
This is only allowed if there is a vertical line such that all regions to the left are assigned to layers with index < layerIdx,
 and all regions to the right are assigned to layers with index > layerIdx.

