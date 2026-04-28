---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalAnalyticalNode.CanDisconnectFromUpstreamNode(Autodesk.Revit.DB.ElementId)
source: html/a5d77780-b6e8-6657-b0b1-e629bd145ee6.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalAnalyticalNode.CanDisconnectFromUpstreamNode Method

Verifies that the current node can disconnect from the upstream node.

## Syntax (C#)
```csharp
public bool CanDisconnectFromUpstreamNode(
	ElementId upstreamNodeId
)
```

## Parameters
- **upstreamNodeId** (`Autodesk.Revit.DB.ElementId`) - The upstream node id.

## Returns
True if the current node can disconnect from the upstream node.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

