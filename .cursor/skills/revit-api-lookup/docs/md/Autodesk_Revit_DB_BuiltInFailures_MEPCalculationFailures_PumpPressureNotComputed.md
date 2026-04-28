---
kind: property
id: P:Autodesk.Revit.DB.BuiltInFailures.MEPCalculationFailures.PumpPressureNotComputed
source: html/f3bd1946-cb39-a4d3-0a15-e1fe9e4acb7c.htm
---
# Autodesk.Revit.DB.BuiltInFailures.MEPCalculationFailures.PumpPressureNotComputed Property

The calculated pressure drop of this pump is not computed because the critical path is not a closed loop. Check to see if there are other pumps intended for use within a secondary/tertiary loop. Use the Add Separation tool to define the secondary/tertiary loop.

## Syntax (C#)
```csharp
public static FailureDefinitionId PumpPressureNotComputed { get; }
```

