---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyDataSettings.UseCurrentViewOnly
source: html/9584554b-3755-eb72-685d-14485da6631f.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.UseCurrentViewOnly Property

True if only elements visible in the currently active view are used for generation of Energy Model.

## Syntax (C#)
```csharp
public bool UseCurrentViewOnly { get; set; }
```

## Remarks
This setting is ignored if the currently active view is not a 3D view or AnalysisType is RoomsOrSpaces.

