---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyAnalysisDetailModelOptions.SimplifyCurtainSystems
source: html/5ffb0eb4-4864-a358-e4b8-16b32e41b8fd.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisDetailModelOptions.SimplifyCurtainSystems Property

Indicates if to specify the setting for simplified curtain systems.

## Syntax (C#)
```csharp
public bool SimplifyCurtainSystems { get; set; }
```

## Remarks
Curtain Walls and Curtain Systems are normally exported as several openings, panel by panel,
 while for energy analysis all you need is one giant window. A curtain wall with 50 panels
 gets exported as 50 openings, while 1 opening with the total opening area would be more appropriate.
 When this setting is on, one "large" window/opening will be exported for a curtain wall/system

