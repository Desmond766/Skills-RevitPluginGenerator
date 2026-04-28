---
kind: method
id: M:Autodesk.Revit.DB.ViewCropRegionShapeManager.GetSplitRegionOffset(System.Int32)
source: html/f2df4fe9-0771-4ee0-e000-d0d2b11ea35f.htm
---
# Autodesk.Revit.DB.ViewCropRegionShapeManager.GetSplitRegionOffset Method

Returns the offset for the specified split crop region.

## Syntax (C#)
```csharp
public XYZ GetSplitRegionOffset(
	int regionIndex
)
```

## Parameters
- **regionIndex** (`System.Int32`) - Index of the split crop region (numbering starts with 0).

## Returns
A vector in model space representing the offset which is applied to the split crop region's boundary.

## Remarks
The points in the split crop region's boundary are not in model space.
 Add the offset returned by this method to each point in the crop region's
 boundary to transform the points into model space coordinates.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The provided region index is invalid.

