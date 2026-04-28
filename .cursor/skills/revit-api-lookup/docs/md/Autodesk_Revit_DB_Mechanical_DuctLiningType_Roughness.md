---
kind: property
id: P:Autodesk.Revit.DB.Mechanical.DuctLiningType.Roughness
source: html/c02389ef-026f-12b6-a4e1-90e74f7626a9.htm
---
# Autodesk.Revit.DB.Mechanical.DuctLiningType.Roughness Property

The roughness of Duct Lining.

## Syntax (C#)
```csharp
public double Roughness { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The roughness value should be at least equal to or larger than 0.
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - When setting this property: None of the following disciplines is enabled: Mechanical Electrical Piping.

