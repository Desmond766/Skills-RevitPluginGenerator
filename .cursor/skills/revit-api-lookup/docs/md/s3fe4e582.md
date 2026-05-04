---
kind: property
id: P:Autodesk.Revit.DB.View.CropBoxActive
zh: 视图
source: html/209ac97b-48ac-ebf8-832b-91b02eb62c93.htm
---
# Autodesk.Revit.DB.View.CropBoxActive Property

**中文**: 视图

Whether or not the Crop Box/Region is active for the view.

## Syntax (C#)
```csharp
public bool CropBoxActive { get; set; }
```

## Remarks
Identifies whether the crop region modifies the graphical appearance of
elements in the view.

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - Thrown when getting this property, 
if the view is a template and cannot have a crop box applied.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when setting this property, 
if the view is a template and cannot have a crop box applied.

