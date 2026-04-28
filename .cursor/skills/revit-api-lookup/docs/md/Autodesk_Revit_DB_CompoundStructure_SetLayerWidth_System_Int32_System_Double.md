---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.SetLayerWidth(System.Int32,System.Double)
source: html/9b801ee8-b10b-dbef-313d-b0ef0d555ea4.htm
---
# Autodesk.Revit.DB.CompoundStructure.SetLayerWidth Method

Sets the width of a specified layer.

## Syntax (C#)
```csharp
public void SetLayerWidth(
	int layerIdx,
	double width
)
```

## Parameters
- **layerIdx** (`System.Int32`) - Index of a layer in the CompoundStructure.
- **width** (`System.Double`) - The new width of the specified layer.

## Remarks
If the structure is vertically compound, and the layer is associated to a single simple region,
 the width of that region is adjusted. If layerIdx is 0 or LayerCount-1,
 and there is no associated region in the VerticalRegionsStructure, one will be created and associated to the layer.
 If the specified layer index is associated to a simple region, and the width is set to 0.0, that region will be deleted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The width of the layer is not valid.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The layer index is out of range.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - If the region of the layer is not a simple region.

