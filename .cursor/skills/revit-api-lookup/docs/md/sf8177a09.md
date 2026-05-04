---
kind: method
id: M:Autodesk.Revit.DB.Electrical.AreaBasedLoadData.CanDisconnectFromUpstreamNode
source: html/5bdfacad-3210-89cc-2ea6-5e7c8412c08b.htm
---
# Autodesk.Revit.DB.Electrical.AreaBasedLoadData.CanDisconnectFromUpstreamNode Method

Verifies that the area based load can disconnect from the upstream electrical analytical node.
 If the area based load hasn't an upstream node, it can't disconnect from the upstream node.

## Syntax (C#)
```csharp
public bool CanDisconnectFromUpstreamNode()
```

## Returns
True if the area based load can disconnect from the upstream electrical analytical node.

## Remarks
If the area based load supplies from Node A, Node A is the upstream node of the area based load, and the area based load is the downstream node of node A.

