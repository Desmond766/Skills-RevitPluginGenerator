---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyDataSettings.IsExportMullionsEnabled
source: html/968592ed-b618-386f-ca4e-79a07a67484c.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.IsExportMullionsEnabled Property

Indicates if mullions are included in GreenBuildingXML export of the detailed model.

## Syntax (C#)
```csharp
public bool IsExportMullionsEnabled { get; }
```

## Remarks
Result is based on the ExportComplexity setting.
 When this setting is on, mullions will be exported as shading surfaces. A "simplified" analytical
 shading surface is produced from a mullion based on its centerline, thickness, and offset.

