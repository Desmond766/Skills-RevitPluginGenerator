---
kind: method
id: M:Autodesk.Revit.DB.Form.GetCurvesAndEdgesReference(Autodesk.Revit.DB.Reference)
zh: 对话框、窗口、窗体
source: html/9d505fbd-7fa2-937c-d0b8-7f4d78d97b51.htm
---
# Autodesk.Revit.DB.Form.GetCurvesAndEdgesReference Method

**中文**: 对话框、窗口、窗体

Given a point, return all edges and curves that it is lying on.

## Syntax (C#)
```csharp
public ReferenceArray GetCurvesAndEdgesReference(
	Reference pointReference
)
```

## Parameters
- **pointReference** (`Autodesk.Revit.DB.Reference`) - The reference of a point.

## Returns
Reference array containing all edges and curves that the point is lying on.

