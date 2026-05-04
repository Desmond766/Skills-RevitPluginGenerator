---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalAnalyticalNode.GetUpstreamNodeIds
source: html/8f3adbf1-ccaa-dc1f-8440-a8cdf9ba747c.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalAnalyticalNode.GetUpstreamNodeIds Method

Gets upstream node ids.

## Syntax (C#)
```csharp
public IList<ElementId> GetUpstreamNodeIds()
```

## Returns
The array of upstream node ids.

## Remarks
If node B supplies from node A, node B is the downstream node of node A, and node A is the upstream node of node B.
 Usually one node only has one upstream node, but TransferSwitch may have two upstream nodes.

