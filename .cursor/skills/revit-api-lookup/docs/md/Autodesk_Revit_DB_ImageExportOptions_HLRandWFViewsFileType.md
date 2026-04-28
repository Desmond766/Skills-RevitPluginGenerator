---
kind: property
id: P:Autodesk.Revit.DB.ImageExportOptions.HLRandWFViewsFileType
source: html/43d9d802-42bd-b161-a249-a133be427d28.htm
---
# Autodesk.Revit.DB.ImageExportOptions.HLRandWFViewsFileType Property

File type for exported HLR and wireframe views.

## Syntax (C#)
```csharp
public ImageFileType HLRandWFViewsFileType { get; set; }
```

## Remarks
The default is JPEGMedium.
 This field is ignored if used to save an image to a project as a new view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

