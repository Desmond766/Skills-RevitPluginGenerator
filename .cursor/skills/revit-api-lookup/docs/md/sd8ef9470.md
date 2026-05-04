---
kind: method
id: M:Autodesk.Revit.DB.ViewCropRegionShapeManager.GetSplitRegionMinimum(System.Int32)
source: html/62230272-ac48-3856-91a3-d5c6aa2ec031.htm
---
# Autodesk.Revit.DB.ViewCropRegionShapeManager.GetSplitRegionMinimum Method

Returns the proportional location of the minimum boundary of the specified split crop region.

## Syntax (C#)
```csharp
public double GetSplitRegionMinimum(
	int regionIndex
)
```

## Parameters
- **regionIndex** (`System.Int32`) - Index of split crop region (numbering starts with 0).

## Returns
A value from 0 to 1 representing the minimum location for the region's split boundary.
 This number represents the location as a ratio along the non-split rectangular crop.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The provided region index is invalid.

