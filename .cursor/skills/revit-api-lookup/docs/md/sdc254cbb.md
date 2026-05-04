---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyDataSettings.IsExportSimplifiedCurtainSystemsEnabled
source: html/96457e45-6195-50c6-653c-0976110d8657.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.IsExportSimplifiedCurtainSystemsEnabled Property

Indicates if curtain system geometry is being simplified for GreenBuildingXML export of the detailed model.

## Syntax (C#)
```csharp
public bool IsExportSimplifiedCurtainSystemsEnabled { get; }
```

## Remarks
Result is based on the ExportComplexity setting.
 Curtain Walls and Curtain Systems are normally exported as multiple openings, panel by panel, while for
 energy analysis this can be more simply represented as a single glass surface as large as the entire curtain wall/system.
 Normally, a curtain wall with 50 panels would be exported as 50 openings. Often, exporting a single opening with
 the total curtain system area is more appropriate. When this setting is on, one "large" window/opening will be
 exported for a curtain wall/system.

