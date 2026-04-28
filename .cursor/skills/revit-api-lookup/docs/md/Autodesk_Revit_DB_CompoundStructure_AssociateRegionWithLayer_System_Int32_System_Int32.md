---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.AssociateRegionWithLayer(System.Int32,System.Int32)
source: html/e0e669e0-97dd-5797-d75d-151fb3634af4.htm
---
# Autodesk.Revit.DB.CompoundStructure.AssociateRegionWithLayer Method

Associates a region with a layer.

## Syntax (C#)
```csharp
public void AssociateRegionWithLayer(
	int regionId,
	int layerIdx
)
```

## Parameters
- **regionId** (`System.Int32`) - The id of a region.
- **layerIdx** (`System.Int32`) - The index of a layer in this CompoundStructure.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - It is not a valid region id.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The layer index is out of range.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is valid only for vertically compound structures.

