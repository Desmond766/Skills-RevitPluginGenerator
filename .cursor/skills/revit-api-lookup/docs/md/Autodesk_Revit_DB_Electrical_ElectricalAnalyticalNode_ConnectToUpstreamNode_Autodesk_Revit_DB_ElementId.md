---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalAnalyticalNode.ConnectToUpstreamNode(Autodesk.Revit.DB.ElementId)
source: html/ff97d96b-a3ed-7ad6-c428-a4a274088c9a.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalAnalyticalNode.ConnectToUpstreamNode Method

Connects to upstream node.

## Syntax (C#)
```csharp
public void ConnectToUpstreamNode(
	ElementId upstreamNodeId
)
```

## Parameters
- **upstreamNodeId** (`Autodesk.Revit.DB.ElementId`) - The upstream node id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The id is not an analytical distribution node id.
 -or-
 The analytical distribution node is full of downstream nodes.
 -or-
 The analytical distribution node can not connect to the upstream node.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The analytical distribution node is full of upstream nodes.

