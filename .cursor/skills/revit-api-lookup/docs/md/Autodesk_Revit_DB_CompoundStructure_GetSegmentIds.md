---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetSegmentIds
source: html/1d87764d-287c-2cf8-c9d9-4184fe7e40e9.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetSegmentIds Method

Gets the segment ids of this compound structure.

## Syntax (C#)
```csharp
public IList<int> GetSegmentIds()
```

## Returns
The ids of the segments which form the boundary of the regions of this CompoundStructure.

## Remarks
The boundaries of the regions of a vertically compound structure consist of vertical
 horizontal segments with unique ids.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is valid only for vertically compound structures.

