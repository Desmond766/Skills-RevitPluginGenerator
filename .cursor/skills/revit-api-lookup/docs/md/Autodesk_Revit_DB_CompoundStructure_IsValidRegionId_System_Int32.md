---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.IsValidRegionId(System.Int32)
source: html/2497dbbd-18fd-0e88-e85c-f456327b8ee4.htm
---
# Autodesk.Revit.DB.CompoundStructure.IsValidRegionId Method

Determines whether the specified integer is actually the id of a region in this CompoundStructure.

## Syntax (C#)
```csharp
public bool IsValidRegionId(
	int regionId
)
```

## Parameters
- **regionId** (`System.Int32`) - The id of a region in this vertically compound structure.

## Returns
True if the region is valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is valid only for vertically compound structures.

