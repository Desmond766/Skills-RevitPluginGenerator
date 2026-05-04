---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricArea.GetBoundaryCurveIds
source: html/eae59f38-12a2-87cb-a153-642aa88d6c55.htm
---
# Autodesk.Revit.DB.Structure.FabricArea.GetBoundaryCurveIds Method

Retrieves the identifiers of the set of curves forming the boundary of the Fabric Area.

## Syntax (C#)
```csharp
public IList<ElementId> GetBoundaryCurveIds()
```

## Returns
A collection of ElementIds of FabricAreaCurve elements.

## Remarks
Each ElementId in the collection is an Id of an Element of type CurveElem.

