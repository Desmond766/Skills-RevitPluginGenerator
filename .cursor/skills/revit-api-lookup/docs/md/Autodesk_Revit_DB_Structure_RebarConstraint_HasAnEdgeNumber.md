---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.HasAnEdgeNumber
source: html/d8150a7f-a810-e4ae-ef8a-dc60545d00a2.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.HasAnEdgeNumber Method

Checks if the getTargetRebarEdgeNumber method can be called for the RebarConstraint.

## Syntax (C#)
```csharp
public bool HasAnEdgeNumber()
```

## Remarks
The RebarConstraintType of the RebarConstraint must be 'ToOtherRebar,' and the
 RebarTargetConstraintType must be 'Edge' or 'BarBend.'

