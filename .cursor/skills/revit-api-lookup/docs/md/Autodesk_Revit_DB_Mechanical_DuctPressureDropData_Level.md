---
kind: property
id: P:Autodesk.Revit.DB.Mechanical.DuctPressureDropData.Level
zh: 标高
source: html/4c461eeb-7be6-86a9-d81d-9f35873c0a78.htm
---
# Autodesk.Revit.DB.Mechanical.DuctPressureDropData.Level Property

**中文**: 标高

The calculation level of the system.

## Syntax (C#)
```csharp
public SystemCalculationLevel Level { get; }
```

## Remarks
If the calculation level is Flow, all parameters that need friction will be displayed as "Not Computed" in Properties dialog (Friction, Pressure Drop, Loss Coefficient).
 If the calculation level is None, all parameters that need flow will be displayed as "Not Computed" in Properties dialog (Velocity, Velocity Pressure, Reynolds number, Friction, Pressure Drop, Loss Coefficient).
 If the calculation level is All, all parameters will be displayed with their actual values in Properties dialog.

