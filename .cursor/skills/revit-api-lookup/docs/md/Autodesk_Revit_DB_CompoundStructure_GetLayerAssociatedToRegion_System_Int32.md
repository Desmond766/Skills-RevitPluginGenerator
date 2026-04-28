---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetLayerAssociatedToRegion(System.Int32)
source: html/60537f57-d0f8-082d-3181-a6097550730d.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetLayerAssociatedToRegion Method

Gets the layer associated to a particular region.

## Syntax (C#)
```csharp
public int GetLayerAssociatedToRegion(
	int regionId
)
```

## Parameters
- **regionId** (`System.Int32`) - The id of a region.

## Returns
The index of a layer in this CompoundStructure.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - For a non-vertically compound structure, implicitly each layer is associated to its corresponding simple region.

