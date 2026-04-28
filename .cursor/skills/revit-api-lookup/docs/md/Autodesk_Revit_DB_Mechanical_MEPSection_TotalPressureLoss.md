---
kind: property
id: P:Autodesk.Revit.DB.Mechanical.MEPSection.TotalPressureLoss
source: html/f75e82be-d681-544c-641f-c943765ef2be.htm
---
# Autodesk.Revit.DB.Mechanical.MEPSection.TotalPressureLoss Property

The total pressure loss of the section.

## Syntax (C#)
```csharp
public double TotalPressureLoss { get; }
```

## Remarks
It's total of all fittings and segments.
 Default unit is Kgf per square feet.
 For Duct, unit type is UT_HVAC_Pressure.
 For Pipe, unit type is UT_Piping_Pressure.

