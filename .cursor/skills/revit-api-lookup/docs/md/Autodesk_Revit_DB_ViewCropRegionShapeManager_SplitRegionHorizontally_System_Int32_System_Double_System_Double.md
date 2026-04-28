---
kind: method
id: M:Autodesk.Revit.DB.ViewCropRegionShapeManager.SplitRegionHorizontally(System.Int32,System.Double,System.Double)
source: html/081c29af-0877-a5ce-bb49-e39ba262a43f.htm
---
# Autodesk.Revit.DB.ViewCropRegionShapeManager.SplitRegionHorizontally Method

Splits horizontally one region in split crop.

## Syntax (C#)
```csharp
public void SplitRegionHorizontally(
	int regionIndex,
	double leftPart,
	double rightPart
)
```

## Parameters
- **regionIndex** (`System.Int32`) - Index of region to be split horizontally (numbering starts with 0).
- **leftPart** (`System.Double`) - Relative portion of the original region to become the new left region (0 to 1).
- **rightPart** (`System.Double`) - Relative portion of the original region to become the new right region (0 to 1).

## Remarks
This function splits the crop into two regions: one occupying the left quarter of the crop, and the other the right quarter of the crop.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The provided view region proportions are not valid.
 -or-
 The provided region index is invalid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The crop of the associated view is not permitted to have multiple regions.
 -or-
 The view has non-rectangular crop shape set.
 -or-
 The view crop is already split vertically.

