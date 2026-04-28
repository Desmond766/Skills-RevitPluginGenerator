---
kind: property
id: P:Autodesk.Revit.DB.Structure.ReinforcementSettings.HostStructuralRebar
source: html/e778d21b-369f-ffc2-ab0f-9191fec3cd8f.htm
---
# Autodesk.Revit.DB.Structure.ReinforcementSettings.HostStructuralRebar Property

Host Structural Rebar within Area and Path Reinforcement with touching AtomHostStructuralRebar.

## Syntax (C#)
```csharp
public bool HostStructuralRebar { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: Cannot change the RebarShapeDefinesHooks property in these settings because the document contains one or more AreaReinforcement or PathReinforcement
 elements.

