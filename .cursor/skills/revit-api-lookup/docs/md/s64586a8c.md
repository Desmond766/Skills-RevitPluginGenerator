---
kind: method
id: M:Autodesk.Revit.DB.Analysis.MEPAnalyticalNode.IsSameNode(Autodesk.Revit.DB.Analysis.MEPAnalyticalNode)
source: html/f11948ee-29b8-0450-75f7-0584dfa024f2.htm
---
# Autodesk.Revit.DB.Analysis.MEPAnalyticalNode.IsSameNode Method

Verify if this node is connected to the other node and thus represents the same analytical node in the network.

## Syntax (C#)
```csharp
public bool IsSameNode(
	MEPAnalyticalNode other
)
```

## Parameters
- **other** (`Autodesk.Revit.DB.Analysis.MEPAnalyticalNode`) - The other node to be compared.

## Returns
True if two nodes represent the same node of the network. Otherwise false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

