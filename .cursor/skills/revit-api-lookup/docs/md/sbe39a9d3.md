---
kind: property
id: P:Autodesk.Revit.DB.Analysis.MassLevelData.MaterialType
source: html/c3164139-a696-7153-ed7e-eebc42f0186f.htm
---
# Autodesk.Revit.DB.Analysis.MassLevelData.MaterialType Property

Indicates if the material used for the graphical appearance is by category or a specific material, or
 if the material to be used should be taken from the ConceptualConstructionType of the MassLevelData.

## Syntax (C#)
```csharp
public MassSurfaceDataMaterialType MaterialType { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The material type does not fall within an appropriate range.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

