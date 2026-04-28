---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyDataSettings.CoreOffset
source: html/c334bad0-d75f-2881-f6b2-a220453cd44e.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.CoreOffset Property

The default offset used to determine the outer perimeter to be divided into zones.

## Syntax (C#)
```csharp
public double CoreOffset { get; set; }
```

## Remarks
A Zone can be either a Mass Zone or an Analytical Space depending on whether the AnalysisType is ConceptualMasses or otherwise.
 Specifying a value here determines the zone depth and creates a core zone.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for coreOffset must be between 0 and 30000 feet.

