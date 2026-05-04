---
kind: method
id: M:Autodesk.Revit.DB.Electrical.AreaBasedLoadData.DisconnectFromUpstreamNode
source: html/8d862062-1657-5ba3-b610-365d7a0b0d83.htm
---
# Autodesk.Revit.DB.Electrical.AreaBasedLoadData.DisconnectFromUpstreamNode Method

Disconnects from an upstream electrical analytical node.

## Syntax (C#)
```csharp
public void DisconnectFromUpstreamNode()
```

## Remarks
If the area based load supplies from Node A, Node A is the upstream node of the area based load, and the area based load is the downstream node of node A.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The area based load can not disconnect from the upstream electrical analytical node.

