---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyDataSettings.PercentageSkylights
source: html/e9696dc1-548e-556a-57df-4571ec3474a7.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.PercentageSkylights Property

Used for the conceptual energy model.
 The approximate percentage of the building roof surfaces in
 massing instances for the Conceptual Energy Analytical Model.

## Syntax (C#)
```csharp
public double PercentageSkylights { get; set; }
```

## Remarks
This value is used to automatically model the skylights in
 massing instances when the Energy Analytical model is being created.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The percentage skylights value is between 0.00 and 0.95.

