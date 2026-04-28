---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyDataSettings.BuildingEnvelopeDeterminationMethod
source: html/c2b5d048-aad6-989b-cd15-4386dc5c1080.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.BuildingEnvelopeDeterminationMethod Property

Indicates if an analysis should be perform to find the model elements that are part of the building envelope

## Syntax (C#)
```csharp
public gbXMLExportBuildingEnvelope BuildingEnvelopeDeterminationMethod { get; set; }
```

## Remarks
The analysis is performed for the detailed GreenBuildingXML export and in heating and cooling load calculations.
 This method uses a combination of ray-casting and flood-fill algorithms in order to find the building elements that are
 exposed to the outside of the building. Analytical surface originated from the building elements in the envelope
 will be classified as exterior or shading surfaces.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The building envelope determination method does not fall within an appropriate range.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

