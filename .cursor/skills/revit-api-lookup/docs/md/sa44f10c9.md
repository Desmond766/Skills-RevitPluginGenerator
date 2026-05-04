---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetPreviousNonZeroLayerIndex(System.Int32)
source: html/98a0b5c3-e17e-661c-9668-1cb535241ff5.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetPreviousNonZeroLayerIndex Method

Returns the index of the nearest non-zero width layer before this layer.

## Syntax (C#)
```csharp
public int GetPreviousNonZeroLayerIndex(
	int thisIdx
)
```

## Parameters
- **thisIdx** (`System.Int32`) - The layer from which to look for a non-zero width layer.

## Returns
The index of the layer found.

## Remarks
If this layer is non-zero width, it will be returned. If there are non-zero width layers found, returns -1.

