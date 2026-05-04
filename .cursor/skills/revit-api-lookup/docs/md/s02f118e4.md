---
kind: property
id: P:Autodesk.Revit.DB.FBXExportOptions.StopOnError
source: html/337903ff-a178-c3c4-6627-d027ae3b0404.htm
---
# Autodesk.Revit.DB.FBXExportOptions.StopOnError Property

Whether export process should stop when a view fails to export.

## Syntax (C#)
```csharp
public bool StopOnError { get; set; }
```

## Remarks
If set to false, the export would continue until all views are processed. 
This option has an effect only when a set of more than one view is specified.

