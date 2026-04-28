---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetExtendableRegionIds(System.Boolean)
source: html/75834253-b686-6284-46ab-a60d45f4c6a2.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetExtendableRegionIds Method

Gets the extendable region ids for the compound structure.

## Syntax (C#)
```csharp
public IList<int> GetExtendableRegionIds(
	bool top
)
```

## Parameters
- **top** (`System.Boolean`) - If true, retrieve ids of regions which are extendable at the top, otherwise
 retrieve the ids of regions which are extendable at the bottom.

## Returns
An array of region ids which are marked extendable.

## Remarks
Regions along the top or bottom of the wall may be set to be extendable.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is valid only for vertically compound structures.

