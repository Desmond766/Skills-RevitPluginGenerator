---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.DeleteLayer(System.Int32)
source: html/64688e23-2d51-b072-35db-8e5b74e95804.htm
---
# Autodesk.Revit.DB.CompoundStructure.DeleteLayer Method

Deletes the specified layer from this CompoundStructure.

## Syntax (C#)
```csharp
public bool DeleteLayer(
	int layerIdx
)
```

## Parameters
- **layerIdx** (`System.Int32`) - The layer index is zero based. It counts from the exterior of wall and from the top of roofs, floors and ceilings.

## Returns
True if the layer was successfully deleted, and false otherwise.

## Remarks
For a vertically compound structure, a layer
 may only be deleted if it is not associated to a region, or else it is associated to exactly one simple
 region, which will also be deleted. Regions associated to layers with index greater than layerIdx will
 have their associated layer indices decremented by one.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The layer cannot be deleted.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The layer index is out of range.

