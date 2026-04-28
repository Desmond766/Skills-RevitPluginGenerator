---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalAnalyticalNode.GetAllDownstreamLoadIds
source: html/6d99429d-8994-86c8-c99e-6095096d8454.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalAnalyticalNode.GetAllDownstreamLoadIds Method

Get all the descendant Electrical Analytical Load ids of the node.

## Syntax (C#)
```csharp
public ISet<ElementId> GetAllDownstreamLoadIds()
```

## Remarks
No matter the load is on stand by or not, the load id will be included in the returned load ids set.

