---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyAnalysisDetailModelOptions.EnergyModelType
source: html/74be020b-ad05-834c-71ba-8dcd7cf6ae37.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisDetailModelOptions.EnergyModelType Property

It indicates whether the energy model is based on rooms/spaces or building elements.

## Syntax (C#)
```csharp
public EnergyModelType EnergyModelType { get; set; }
```

## Remarks
The default value is EnergyModelType::SpatialElement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

