---
kind: property
id: P:Autodesk.Revit.DB.View.CropBoxVisible
zh: 视图
source: html/664d8061-a4bf-0aca-73dc-fbee2bd18174.htm
---
# Autodesk.Revit.DB.View.CropBoxVisible Property

**中文**: 视图

Whether or not the Crop Box/Region is visible for the view.

## Syntax (C#)
```csharp
public bool CropBoxVisible { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - Thrown when getting this property, 
if the view is a template and cannot have a crop box applied.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when setting this property, 
if the view is a template and cannot have a crop box applied.

