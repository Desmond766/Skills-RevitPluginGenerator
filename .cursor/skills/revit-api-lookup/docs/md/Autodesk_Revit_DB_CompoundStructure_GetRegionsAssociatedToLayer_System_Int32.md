---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetRegionsAssociatedToLayer(System.Int32)
source: html/682ac400-fff2-f729-f529-c6b95c96c860.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetRegionsAssociatedToLayer Method

Gets the set of region ids associated to a particular layer.

## Syntax (C#)
```csharp
public IList<int> GetRegionsAssociatedToLayer(
	int layerIdx
)
```

## Parameters
- **layerIdx** (`System.Int32`) - The index of a layer in this CompoundStructure.

## Returns
An array of region ids which are associated to the specified layer.

## Remarks
Regions are associated to layers. In a vertically compound structure, more than one region may be associated to a
 single layer.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The layer index is out of range.

