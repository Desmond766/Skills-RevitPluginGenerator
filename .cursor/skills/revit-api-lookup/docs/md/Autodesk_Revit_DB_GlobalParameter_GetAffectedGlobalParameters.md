---
kind: method
id: M:Autodesk.Revit.DB.GlobalParameter.GetAffectedGlobalParameters
source: html/2028f8a1-2691-e921-8a56-882b1e4080f3.htm
---
# Autodesk.Revit.DB.GlobalParameter.GetAffectedGlobalParameters Method

Returns all other global parameters which refer to this global parameter in their formulas.

## Syntax (C#)
```csharp
public ISet<ElementId> GetAffectedGlobalParameters()
```

## Returns
Collection of Element Ids.

## Remarks
The method returns other global parameters that directly (in their formulas) refer
 to this parameter. For example, if P1 refers to P0 (e.g. [= 2.5 * P0]), and P2 refers
 to P1 (e.g. [= P1 + 3.14]), then the set of parameters affected directly by P0 would
 only contain one parameter - P1. Naturally, be using this method repeatedly, firts
 on P0 and then P1 (assuming the above example), the programmer can eventually collect
 all depending global parameters, whether they refer to P0 directly or indirectly.

