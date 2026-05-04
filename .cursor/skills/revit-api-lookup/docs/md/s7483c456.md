---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyDataSettings.IsExportShadingSurfacesEnabled
source: html/9d249657-2528-8e39-304f-c62e98d77778.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.IsExportShadingSurfacesEnabled Property

Indicates if "shading surfaces" are included in GreenBuildingXML export of the detailed model.

## Syntax (C#)
```csharp
public bool IsExportShadingSurfacesEnabled { get; }
```

## Remarks
Result is based on the ExportComplexity setting.
 The method described by gbs/gbxml.org to calculate the shading surfaces is to
 take all surfaces from the MEP spaces, subtract them from the surfaces from all building elements,
 and then the remaining surfaces are considered to be the shading surfaces.

