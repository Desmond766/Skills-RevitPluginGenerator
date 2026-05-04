---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyDataSettings.BuildingConstructionClass
source: html/3427f2cb-5fde-abdc-3c6e-b513f2c58034.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.BuildingConstructionClass Property

Used for both the detailed and conceptual energy model
 Construction class of building as defined by:
 loose, medium, tight, or none.

## Syntax (C#)
```csharp
public HVACLoadConstructionClass BuildingConstructionClass { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The building construction class does not fall within an appropriate range.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

