---
kind: method
id: M:Autodesk.Revit.DB.Electrical.AreaBasedLoadData.ConnectToUpstreamNode(Autodesk.Revit.DB.ElementId)
source: html/16a78358-8e4a-3150-5574-3ed21f3a64b4.htm
---
# Autodesk.Revit.DB.Electrical.AreaBasedLoadData.ConnectToUpstreamNode Method

Connects to an upstream electrical analytical node.

## Syntax (C#)
```csharp
public void ConnectToUpstreamNode(
	ElementId upstreamNodeId
)
```

## Parameters
- **upstreamNodeId** (`Autodesk.Revit.DB.ElementId`) - The upstream electrical analytical node id.

## Remarks
If the area based load supplies from Node A, Node A is the upstream node of the area based load, and the area based load is the downstream node of node A.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The id is not an electrical analytical node id.
 -or-
 The area based load can not connect to the upstream electrical analytical node.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

