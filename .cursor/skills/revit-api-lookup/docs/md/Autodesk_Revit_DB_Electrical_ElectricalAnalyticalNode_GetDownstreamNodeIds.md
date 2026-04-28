---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalAnalyticalNode.GetDownstreamNodeIds
source: html/5ff642a5-6bb9-fc6f-6b1a-52f337a9be5d.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalAnalyticalNode.GetDownstreamNodeIds Method

Gets the downstream node ids.

## Syntax (C#)
```csharp
public IList<ElementId> GetDownstreamNodeIds()
```

## Returns
The array of downstream node ids.

## Remarks
If node B supplies from node A, node B is the downstream node of node A, and node A is the upstream node of node B.
 Usually one node may have many downstream nodes, but TransferSwitch can only have one downstream node.

