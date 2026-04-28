---
kind: property
id: P:Autodesk.Revit.DB.Document.ActiveProjectLocation
zh: 文档、文件
source: html/cd6733bb-4510-bb58-5ca5-21ededb30cdf.htm
---
# Autodesk.Revit.DB.Document.ActiveProjectLocation Property

**中文**: 文档、文件

Retrieve the active project location.

## Syntax (C#)
```csharp
public ProjectLocation ActiveProjectLocation { get; set; }
```

## Remarks
Getting this property returns the currently active project location that 
the user is currently working with. Setting this property can be used to change
the active project location.

