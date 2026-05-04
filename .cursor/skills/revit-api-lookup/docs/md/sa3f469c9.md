---
kind: property
id: P:Autodesk.Revit.DB.ImageExportOptions.ShadowViewsFileType
source: html/0bc687d3-64d3-0e0e-8095-f51cea1634ee.htm
---
# Autodesk.Revit.DB.ImageExportOptions.ShadowViewsFileType Property

The file type for exported shadow views.

## Syntax (C#)
```csharp
public ImageFileType ShadowViewsFileType { get; set; }
```

## Remarks
The default is JPEGMedium.
 This field is ignored if used to save an image to a project as a new view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

