---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaReinforcement.GetBoundaryCurveIds
source: html/75225104-99db-98f2-d407-6ee8f48ad9ae.htm
---
# Autodesk.Revit.DB.Structure.AreaReinforcement.GetBoundaryCurveIds Method

Retrieves the set of curves forming the boundary of the Area Reinforcement.

## Syntax (C#)
```csharp
public IList<ElementId> GetBoundaryCurveIds()
```

## Returns
A collection of ElementIds of AreaReinforcementCurve elements.

## Remarks
Each ElementId in the collection is an Id of an Element of type AreaReinforcementCurve. Each element has a Curve property
 to retrieve the geometric curve, together with some Parameters allowing the developer to override the clear cover side,
 hook type, and hook direction of each layer of bars terminating at the curve.

