---
kind: type
id: T:Autodesk.Revit.DB.Analysis.MassSurfaceData
source: html/69fcb13c-6443-d1c2-29d5-08adc1261afd.htm
---
# Autodesk.Revit.DB.Analysis.MassSurfaceData

Holds properties and other data about a face in the MassEnergyAnalyticalModel element.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This class is deprecated in Revit 2023 and may be removed in a later version of Revit. We suggest you use the 'EnergyAnalyticalDetailModel' and 'EnergyAnalysisSurface' classes instead.")]
public class MassSurfaceData : Element
```

## Remarks
Properties stored in the MassSurfaceData can be used in regeneration by the MassEnergyAnalyticalModel.
 For example, faces of the MassEnergyAnalyticalModel take their material values from the settings
 in the MassSurfaceData.

