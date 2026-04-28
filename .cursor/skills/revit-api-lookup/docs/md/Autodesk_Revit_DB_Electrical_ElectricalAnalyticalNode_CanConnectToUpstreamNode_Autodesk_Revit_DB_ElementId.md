---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalAnalyticalNode.CanConnectToUpstreamNode(Autodesk.Revit.DB.ElementId)
source: html/9a2c6050-dcab-dff8-96bb-35183a60ddf7.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalAnalyticalNode.CanConnectToUpstreamNode Method

Verifies that the current node can connect to the upstream node.

## Syntax (C#)
```csharp
public bool CanConnectToUpstreamNode(
	ElementId upstreamNodeId
)
```

## Parameters
- **upstreamNodeId** (`Autodesk.Revit.DB.ElementId`) - The upstream node id.

## Returns
True if the current node can connect to the upstream node.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

