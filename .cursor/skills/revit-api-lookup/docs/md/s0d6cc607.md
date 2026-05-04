---
kind: method
id: M:Autodesk.Revit.DB.Form.AddProfile(Autodesk.Revit.DB.Reference,System.Double)
zh: 对话框、窗口、窗体
source: html/35a465ec-d7be-cc7d-c76c-dd10e03b7046.htm
---
# Autodesk.Revit.DB.Form.AddProfile Method

**中文**: 对话框、窗口、窗体

Add a profile into the form, by a specified edge/param.

## Syntax (C#)
```csharp
public int AddProfile(
	Reference edgeReference,
	double param
)
```

## Parameters
- **edgeReference** (`Autodesk.Revit.DB.Reference`) - The geometry reference of edge.
- **param** (`System.Double`) - The param on edge to specify the location.

## Returns
Index of newly created profile.

