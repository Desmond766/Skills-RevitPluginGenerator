---
kind: method
id: M:Autodesk.Revit.DB.Analysis.MEPAnalyticalModelData.GetNodeById(System.Int32)
source: html/4cd9a535-f3da-c375-06cd-dfda231933a6.htm
---
# Autodesk.Revit.DB.Analysis.MEPAnalyticalModelData.GetNodeById Method

Gets the analytical node with the specified id.

## Syntax (C#)
```csharp
public MEPAnalyticalNode GetNodeById(
	int nodeId
)
```

## Parameters
- **nodeId** (`System.Int32`) - The node identifier, be aware that this identifier may not be sequentially ordered for all analytical nodes.

## Returns
The returned analytical node.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input must be a valid node id.

