---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyAnalysisDetailModel.SimplifyCurtainSystems
source: html/10efe4ba-a85e-0315-81a8-e37699f379e6.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisDetailModel.SimplifyCurtainSystems Property

Indicates if to specify the setting for simplified curtain systems.

## Syntax (C#)
```csharp
public bool SimplifyCurtainSystems { get; }
```

## Remarks
Curtain Walls and Curtain Systems are normally exported as several openings, panel by panel,
 while for energy analysis all you need is one giant window. A curtain wall with 50 panels
 gets exported as 50 openings, while 1 opening with the total opening area would be more appropriate.
 When this setting is on, one "large" window/opening will be exported for a curtain wall/system

