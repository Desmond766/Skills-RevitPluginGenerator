---
kind: property
id: P:Autodesk.Revit.DB.Electrical.CableTrayType.BendMultiplier
source: html/219e7ed7-5c65-17ce-2afb-b56d54be95e4.htm
---
# Autodesk.Revit.DB.Electrical.CableTrayType.BendMultiplier Property

Bend multiplier.

## Syntax (C#)
```csharp
public double BendMultiplier { get; set; }
```

## Remarks
This should be positive and less than 3000.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The bend multiplier value should be positive and less than 3000.
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - When setting this property: None of the following disciplines is enabled: Mechanical Electrical Piping.

