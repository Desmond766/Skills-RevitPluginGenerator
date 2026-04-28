---
kind: method
id: M:Autodesk.Revit.DB.View3D.ScalePerspectiveCropBox(System.Double)
zh: 三维视图、3d视图
source: html/2eaa6b56-c0d9-2c21-0c6a-d07a10a9d5e9.htm
---
# Autodesk.Revit.DB.View3D.ScalePerspectiveCropBox Method

**中文**: 三维视图、3d视图

Scale an existing crop box of the perspective view.

## Syntax (C#)
```csharp
public void ScalePerspectiveCropBox(
	double multiplier
)
```

## Parameters
- **multiplier** (`System.Double`) - Multiplier to change the view scale and the current crop box size on both X and Y.

## Remarks
Remarks In addition to changing the view crop box, this operation also makes the change analogous to changing the scale of the orthographic view, so that both the size and scale of the view on a sheet changes according to the provided argument 'multiplier'. For getting or setting view crop box size use property CropBox

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Returns true if the view is not a view template.

