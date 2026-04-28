---
kind: method
id: M:Autodesk.Revit.DB.Structure.PathReinforcement.GetCurveElementIds
source: html/6a17f4fa-5d3a-2e3b-ce1c-fefa0dd941dd.htm
---
# Autodesk.Revit.DB.Structure.PathReinforcement.GetCurveElementIds Method

Retrieves the set of ElementIds of curves forming the boundary of the Path Reinforcement.

## Syntax (C#)
```csharp
public IList<ElementId> GetCurveElementIds()
```

## Returns
A collection of ElementIds of ModelCurve elements.

## Remarks
Each ElementId in the collection is an Id of an Element of type ModelCurve.

