---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyDataSettings.PercentageGlazing
source: html/3b754027-2f58-c902-e232-073a663ab85b.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.PercentageGlazing Property

Used for the conceptual energy model.
 The approximate percentage of the building exterior wall surfaces
 which are covered by windows or other glazing.

## Syntax (C#)
```csharp
public double PercentageGlazing { get; set; }
```

## Remarks
This value is used to automatically model these glazed openings in
 massing instances for the Conceptual Energy Analytical Model.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The percentage glazing value is not between 0.00 and 0.95.

