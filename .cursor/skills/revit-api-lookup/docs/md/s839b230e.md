---
kind: method
id: M:Autodesk.Revit.DB.Electrical.AreaBasedLoadData.CanConnectToUpstreamNode(Autodesk.Revit.DB.ElementId)
source: html/6e1ab074-f31d-5780-6b6e-bacfe8a5a1c5.htm
---
# Autodesk.Revit.DB.Electrical.AreaBasedLoadData.CanConnectToUpstreamNode Method

Verifies that the area based load can connect to the upstream electrical analytical node.
 If the area based load already has an upstream node or the upstream node is full of downstream nodes, the area based load can't connect to the upstream node.

## Syntax (C#)
```csharp
public bool CanConnectToUpstreamNode(
	ElementId upstreamNodeId
)
```

## Parameters
- **upstreamNodeId** (`Autodesk.Revit.DB.ElementId`) - The upstream electrical analytical node id.

## Returns
True if the area based load can connect to the upstream electrical analytical node.

## Remarks
If the area based load supplies from Node A, Node A is the upstream node of the area based load, and the area based load is the downstream node of node A.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

