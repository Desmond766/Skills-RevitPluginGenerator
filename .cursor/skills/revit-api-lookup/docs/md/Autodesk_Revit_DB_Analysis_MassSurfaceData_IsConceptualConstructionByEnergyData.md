---
kind: property
id: P:Autodesk.Revit.DB.Analysis.MassSurfaceData.IsConceptualConstructionByEnergyData
source: html/f346fb03-72ad-4ad6-9503-7a883cb5b3ba.htm
---
# Autodesk.Revit.DB.Analysis.MassSurfaceData.IsConceptualConstructionByEnergyData Property

True when the ConceptualConstructionType id is synchronized to the EnergyDataSettings.
 False when the ConceptualConstructionType id is overridden for this MassSurfaceData.

## Syntax (C#)
```csharp
public bool IsConceptualConstructionByEnergyData { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: ConceptualConstructionIsByEnergyData cannot be set to conceptualConstructionIsByEnergyData.

