---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyAnalysisDetailModelOptions.ExportMullions
source: html/04d9f70b-ada4-d0fc-5ce7-b81250dbac8d.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisDetailModelOptions.ExportMullions Property

Indicates if to specify the setting for exporting mullions.

## Syntax (C#)
```csharp
public bool ExportMullions { get; set; }
```

## Remarks
When this setting is on, mullions will be exported as shading surfaces. A "simplified" analytical
 shading surface is produced from a mullion based on its centerline, thickness and offset.

