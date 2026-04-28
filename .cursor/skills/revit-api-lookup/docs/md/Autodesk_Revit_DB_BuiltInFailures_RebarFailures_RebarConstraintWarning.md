---
kind: property
id: P:Autodesk.Revit.DB.BuiltInFailures.RebarFailures.RebarConstraintWarning
source: html/a9357080-9cbf-fb8b-a1be-876b551b70f6.htm
---
# Autodesk.Revit.DB.BuiltInFailures.RebarFailures.RebarConstraintWarning Property

Structural rebar have automatic constraints that may conflict with dimensional constraints. Using dimensional
 constraints with structural rebar is not recommended and should be avoided.\nGrouped structural rebar is the
 only exception to this recommendation, since the automatic constraints are removed on grouped rebar.

## Syntax (C#)
```csharp
public static FailureDefinitionId RebarConstraintWarning { get; }
```

