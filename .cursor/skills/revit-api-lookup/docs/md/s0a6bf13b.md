---
kind: method
id: M:Autodesk.Revit.DB.Electrical.AreaBasedLoadData.GetUpstreamNodeId
source: html/36df9aff-cc37-9dff-85d0-15f265198a76.htm
---
# Autodesk.Revit.DB.Electrical.AreaBasedLoadData.GetUpstreamNodeId Method

Gets the upstream electrical analytical node id.

## Syntax (C#)
```csharp
public ElementId GetUpstreamNodeId()
```

## Returns
The upstream node id.

## Remarks
If the area based load supplies from Node A, Node A is the upstream node of the area based load, and the area based load is the downstream node of node A.

