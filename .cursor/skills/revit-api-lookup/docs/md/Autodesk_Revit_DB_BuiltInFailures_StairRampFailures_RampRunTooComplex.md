---
kind: property
id: P:Autodesk.Revit.DB.BuiltInFailures.StairRampFailures.RampRunTooComplex
source: html/ed9110e3-1b69-7447-2d01-5103a3df034c.htm
---
# Autodesk.Revit.DB.BuiltInFailures.StairRampFailures.RampRunTooComplex Property

Ramp Run has complex boundary and may produce unreasonable geometry. Split it into few Runs by inserting Riser Lines
 at the end of each Run and at the beginning of the next one. If you want to create Ramp with arc an straight section you can do it using a Run tool.

## Syntax (C#)
```csharp
public static FailureDefinitionId RampRunTooComplex { get; }
```

