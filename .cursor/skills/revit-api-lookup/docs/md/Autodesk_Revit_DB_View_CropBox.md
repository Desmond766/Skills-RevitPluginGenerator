---
kind: property
id: P:Autodesk.Revit.DB.View.CropBox
zh: 视图
source: html/d6246051-ecfb-7388-0429-6ed65de72638.htm
---
# Autodesk.Revit.DB.View.CropBox Property

**中文**: 视图

The Crop Box applied to the view, or an outline encompassing the crop region applied to the view.

## Syntax (C#)
```csharp
public BoundingBoxXYZ CropBox { get; set; }
```

## Remarks
The X direction of the box is right on screen; Y is up; and Z is towards the user. The crop box Z value of a plan view is not meaningful.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Cannot set the CropBox of the specified view.

