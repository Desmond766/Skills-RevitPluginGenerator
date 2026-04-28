---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.IsUnconstrained
source: html/4999e26b-8de2-5db8-ddbf-12e98184773e.htm
---
# Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.IsUnconstrained Method

Returns true if the current rebar doesn't contains a valid server GUID, or contains a valid server GUID and no valid constraints.

## Syntax (C#)
```csharp
public bool IsUnconstrained()
```

## Returns
Returns true if the current rebar doesn't contains a valid server GUID, or contains a valid server GUID and no valid constraints.
 Returns false if the current rebar contains a valid server GUID and has valid constraints.

