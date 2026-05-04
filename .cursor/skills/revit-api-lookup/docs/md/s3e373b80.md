---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyAnalysisDetailModel.ExportMullions
source: html/cda25c0e-f426-4a95-96c7-2eaa668cee86.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisDetailModel.ExportMullions Property

Indicates if to specify the setting for exporting mullions.

## Syntax (C#)
```csharp
public bool ExportMullions { get; }
```

## Remarks
When this setting is on, mullions will be exported as shading surfaces. A "simplified" analytical
 shading surface is produced from a mullion based on its centerline, thickness and offset.

