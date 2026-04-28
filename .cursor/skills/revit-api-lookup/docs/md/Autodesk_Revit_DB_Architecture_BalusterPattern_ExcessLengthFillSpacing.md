---
kind: property
id: P:Autodesk.Revit.DB.Architecture.BalusterPattern.ExcessLengthFillSpacing
source: html/3c54b11b-724a-cd4c-0b80-abcd141fada7.htm
---
# Autodesk.Revit.DB.Architecture.BalusterPattern.ExcessLengthFillSpacing Property

The value defines the spacing between each baluster instance inserted in the excess length.

## Syntax (C#)
```csharp
public double ExcessLengthFillSpacing { get; set; }
```

## Remarks
The spacing is used only if a baluster family is set to excess length fill.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for excessLengthFillSpacing must be between 0 and 30000 feet.

