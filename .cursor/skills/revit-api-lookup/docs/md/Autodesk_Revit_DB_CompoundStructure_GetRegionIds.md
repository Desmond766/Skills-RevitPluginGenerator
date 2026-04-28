---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetRegionIds
source: html/f0349b61-d48a-e5e6-143c-1e2a63069e9f.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetRegionIds Method

Gets the region ids of this compound structure.

## Syntax (C#)
```csharp
public IList<int> GetRegionIds()
```

## Returns
The ids of the regions defining this CompoundStructure.

## Remarks
A vertically compound structure consists of regions with polygonal boundaries.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is valid only for vertically compound structures.

