---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarBarType.MaximumBendRadius
source: html/06aece02-da41-ef43-97e0-bc2d2f17e366.htm
---
# Autodesk.Revit.DB.Structure.RebarBarType.MaximumBendRadius Property

Defines maximum bend radius of rebar

## Syntax (C#)
```csharp
public double MaximumBendRadius { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given value for maximumBendRadius is not a number
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: maximumBendRadius must be greater than 0 and no more than 30000.

