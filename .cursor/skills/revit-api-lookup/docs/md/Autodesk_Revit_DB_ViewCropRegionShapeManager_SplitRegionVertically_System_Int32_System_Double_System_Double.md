---
kind: method
id: M:Autodesk.Revit.DB.ViewCropRegionShapeManager.SplitRegionVertically(System.Int32,System.Double,System.Double)
source: html/583d354f-9950-5bcd-23e0-69c15ee69a50.htm
---
# Autodesk.Revit.DB.ViewCropRegionShapeManager.SplitRegionVertically Method

Splits vertically one region in split crop.

## Syntax (C#)
```csharp
public void SplitRegionVertically(
	int regionIndex,
	double topPart,
	double bottomPart
)
```

## Parameters
- **regionIndex** (`System.Int32`) - Index of region to be split vertically (numbering starts with 0).
- **topPart** (`System.Double`) - Relative portion of the original region to become the new top region (0 to 1).
- **bottomPart** (`System.Double`) - Relative portion of the original region to become the new bottom region (0 to 1).

## Remarks
This function splits the crop into two regions: one occupying the top quarter of the crop, and the other the bottom quarter of the crop.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The provided view region proportions are not valid.
 -or-
 The provided region index is invalid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The crop of the associated view is not permitted to have multiple regions.
 -or-
 The view has non-rectangular crop shape set.
 -or-
 The view crop is already split horizontally.

