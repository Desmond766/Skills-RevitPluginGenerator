---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyDataSettings.IncludeThermalProperties
source: html/ce7f8c60-211d-5f32-f4f4-8d44c638697c.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.IncludeThermalProperties Property

Indicates if thermal information from model assemblies and components is included in GreenBuildingXML export of the detailed model.

## Syntax (C#)
```csharp
public bool IncludeThermalProperties { get; set; }
```

## Remarks
If true, Revit will include model thermal data from assemblies and
 components when available, when Export Category is Rooms.

