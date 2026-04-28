---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.SetLayer(System.Int32,Autodesk.Revit.DB.CompoundStructureLayer)
source: html/3a7e18fd-fcd4-1335-ce10-841d2bfd2322.htm
---
# Autodesk.Revit.DB.CompoundStructure.SetLayer Method

Sets a single layer for this CompoundStructure.

## Syntax (C#)
```csharp
public void SetLayer(
	int layerIdx,
	CompoundStructureLayer layer
)
```

## Parameters
- **layerIdx** (`System.Int32`) - The index of a layer. This should range from 0 to the number of layers - 1.
- **layer** (`Autodesk.Revit.DB.CompoundStructureLayer`) - The layer to be set.

## Remarks
This function does not support addition of new layers, use SetLayers() to change the number of layers.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The layer is not valid for this operation.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The layer index is out of range.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is valid only for non-vertically compound structures.

