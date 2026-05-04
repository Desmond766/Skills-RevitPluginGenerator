---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalAnalyticalNode.DisconnectFromUpstreamNode(Autodesk.Revit.DB.ElementId)
source: html/9d1cdc60-34df-2ca6-8022-8742731743a1.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalAnalyticalNode.DisconnectFromUpstreamNode Method

Disconnects from upstream node.

## Syntax (C#)
```csharp
public void DisconnectFromUpstreamNode(
	ElementId upstreamNodeId
)
```

## Parameters
- **upstreamNodeId** (`Autodesk.Revit.DB.ElementId`) - The upstream node id to disconnect from.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The id is not an analytical distribution node id.
 -or-
 The analytical distribution node can not disconnect from the upstream node.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

