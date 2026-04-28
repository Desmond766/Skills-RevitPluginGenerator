---
kind: method
id: M:Autodesk.Revit.DB.ViewCropRegionShapeManager.RemoveSplitRegion(System.Int32)
source: html/c750ce39-d497-7cab-028b-4da0e0ce3c91.htm
---
# Autodesk.Revit.DB.ViewCropRegionShapeManager.RemoveSplitRegion Method

Removes one region in split crop.

## Syntax (C#)
```csharp
public void RemoveSplitRegion(
	int regionIndex
)
```

## Parameters
- **regionIndex** (`System.Int32`) - Index of region to be deleted (numbering starts with 0).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The provided region index cannot be deleted.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The crop of the associated view is not permitted to have multiple regions.
 -or-
 The view has non-rectangular crop shape set.

