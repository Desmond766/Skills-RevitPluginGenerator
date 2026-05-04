---
kind: method
id: M:Autodesk.Revit.DB.ViewCropRegionShapeManager.GetSplitRegionMaximum(System.Int32)
source: html/fe2685d5-c8c3-eb61-d4d0-3fcdd48820ed.htm
---
# Autodesk.Revit.DB.ViewCropRegionShapeManager.GetSplitRegionMaximum Method

Returns the proportional location of the maximum boundary of the specified split crop region.

## Syntax (C#)
```csharp
public double GetSplitRegionMaximum(
	int regionIndex
)
```

## Parameters
- **regionIndex** (`System.Int32`) - Index of split crop region (numbering starts with 0).

## Returns
A value from 0 to 1 representing the maximum location for the region's split boundary.
 This number represents the location as a ratio along the non-split rectangular crop.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The provided region index is invalid.

