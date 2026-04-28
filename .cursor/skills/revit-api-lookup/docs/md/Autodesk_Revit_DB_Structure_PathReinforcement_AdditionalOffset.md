---
kind: property
id: P:Autodesk.Revit.DB.Structure.PathReinforcement.AdditionalOffset
source: html/07b9ba68-2a6f-8948-a61e-4364be70902c.htm
---
# Autodesk.Revit.DB.Structure.PathReinforcement.AdditionalOffset Property

Additional offset of rebars in the Path Reinforcement.

## Syntax (C#)
```csharp
public double AdditionalOffset { get; set; }
```

## Remarks
The method moves both primary and alternating bars.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for offset must be no more than 30000 feet in absolute value.

