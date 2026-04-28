---
kind: method
id: M:Autodesk.Revit.DB.Form.GetControlPoints(Autodesk.Revit.DB.Reference)
zh: 对话框、窗口、窗体
source: html/04cad91d-8ab0-a4cb-05e6-801266a9cdf9.htm
---
# Autodesk.Revit.DB.Form.GetControlPoints Method

**中文**: 对话框、窗口、窗体

Given an edge or a curve or a face, return all control points lying on it (in form of geometry references).

## Syntax (C#)
```csharp
public ReferenceArray GetControlPoints(
	Reference curveOrEdgeOrFaceReference
)
```

## Parameters
- **curveOrEdgeOrFaceReference** (`Autodesk.Revit.DB.Reference`) - The reference of an edge or curve or face.

## Returns
Reference array containing all control points lying on it.

