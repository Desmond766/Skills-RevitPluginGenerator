---
kind: property
id: P:Autodesk.Revit.DB.DWFExportOptions.StopOnError
source: html/3b8b0e94-5765-aa0d-0dbe-6612ed9183f1.htm
---
# Autodesk.Revit.DB.DWFExportOptions.StopOnError Property

Whether export process should stop when a view fails to export.

## Syntax (C#)
```csharp
public bool StopOnError { get; set; }
```

## Remarks
If set to false, the export would continue until all views are processed. 
This option has an effect only when a set of more than one view is specified.

