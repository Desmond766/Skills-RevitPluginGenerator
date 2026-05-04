---
kind: property
id: P:Autodesk.Revit.DB.DWFExportOptions.ExportObjectData
source: html/87b03ae6-a808-7180-30e6-b22fac2d5168.htm
---
# Autodesk.Revit.DB.DWFExportOptions.ExportObjectData Property

Whether to include properties associated with elements.

## Syntax (C#)
```csharp
public bool ExportObjectData { get; set; }
```

## Remarks
ExportObjectData must be enabled (true) in order to also
enable exporting rooms and areas (ExportingAreas). If ExportObjectData
is disabled, the ExportingAreas property will be ignored.

