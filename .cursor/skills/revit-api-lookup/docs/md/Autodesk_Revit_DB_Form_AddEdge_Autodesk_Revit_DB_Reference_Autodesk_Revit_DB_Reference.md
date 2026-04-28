---
kind: method
id: M:Autodesk.Revit.DB.Form.AddEdge(Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.Reference)
zh: 对话框、窗口、窗体
source: html/d602fe20-990a-b45e-3dde-d3b828668314.htm
---
# Autodesk.Revit.DB.Form.AddEdge Method

**中文**: 对话框、窗口、窗体

Add an edge to the form, connecting two edges on same/different profile, by a pair of specified points.

## Syntax (C#)
```csharp
public void AddEdge(
	Reference startPointReference,
	Reference endPointReference
)
```

## Parameters
- **startPointReference** (`Autodesk.Revit.DB.Reference`) - The geometry reference of start point
- **endPointReference** (`Autodesk.Revit.DB.Reference`) - The geometry reference of end point

