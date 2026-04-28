---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.ChangeRegionWidth(System.Int32,System.Double)
source: html/b4005b2b-b7eb-f191-90ef-32cf9cd3d03a.htm
---
# Autodesk.Revit.DB.CompoundStructure.ChangeRegionWidth Method

Adjust the width of an existing simple region.

## Syntax (C#)
```csharp
public bool ChangeRegionWidth(
	int regionId,
	double newWidth
)
```

## Parameters
- **regionId** (`System.Int32`) - The id of a region.
- **newWidth** (`System.Double`) - The desired width of the specified region.

## Returns
True if newWidth is zero and the region was deleted.

## Remarks
If width is changed to zero, the effect is to delete the region.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - It is not a valid region id.
 -or-
 It is not a simple region.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is valid only for vertically compound structures.

