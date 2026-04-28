---
kind: method
id: M:Autodesk.Revit.DB.Form.AddEdge(Autodesk.Revit.DB.Reference,System.Double,Autodesk.Revit.DB.Reference,System.Double)
zh: 对话框、窗口、窗体
source: html/b82f9bc0-554f-9dbd-a2aa-667de1541d24.htm
---
# Autodesk.Revit.DB.Form.AddEdge Method

**中文**: 对话框、窗口、窗体

Add an edge to the form, connecting two edges on same/different profile, by a pair of specified edge/param.

## Syntax (C#)
```csharp
public void AddEdge(
	Reference startEdgeReference,
	double startParam,
	Reference endEdgeReference,
	double endParam
)
```

## Parameters
- **startEdgeReference** (`Autodesk.Revit.DB.Reference`) - The geometry reference of start edge
- **startParam** (`System.Double`) - The param on start edge to specify the location.
- **endEdgeReference** (`Autodesk.Revit.DB.Reference`) - The geometry reference of end edge
- **endParam** (`System.Double`) - The param on end edge to specify the location.

