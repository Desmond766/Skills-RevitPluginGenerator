---
kind: property
id: P:Autodesk.Revit.DB.BuiltInFailures.DimensionFailures.NoConstraintsInProperSketch
source: html/6d46635c-9470-fcbc-343b-e5cc34b58251.htm
---
# Autodesk.Revit.DB.BuiltInFailures.DimensionFailures.NoConstraintsInProperSketch Property

You are creating a constraint inside the sketch of a property line. Constraints inside a sketch can only drive elements within the sketch. Usually you do not want property lines driven by other elements. If you would like to constrain other elements to the property lines, you should add the constraints outside of sketch mode.

## Syntax (C#)
```csharp
public static FailureDefinitionId NoConstraintsInProperSketch { get; }
```

