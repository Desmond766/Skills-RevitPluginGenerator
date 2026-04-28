---
kind: property
id: P:Autodesk.Revit.DB.Electrical.ElectricalSystem.PathOffset
source: html/33c33ae6-8d62-e419-d8f5-f9b6f670c7f7.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSystem.PathOffset Property

The offset of the horizontal segments of the circuit path.

## Syntax (C#)
```csharp
public double PathOffset { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for pathOffset must be no more than 30000 feet in absolute value.
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - When setting this property: None of the following disciplines is enabled: Mechanical Electrical Piping.

