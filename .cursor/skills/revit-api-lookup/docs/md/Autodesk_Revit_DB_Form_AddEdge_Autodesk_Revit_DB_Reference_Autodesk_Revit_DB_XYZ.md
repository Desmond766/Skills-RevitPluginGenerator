---
kind: method
id: M:Autodesk.Revit.DB.Form.AddEdge(Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.XYZ)
zh: 对话框、窗口、窗体
source: html/24bbd6b3-c43f-15e4-a955-e6559d102405.htm
---
# Autodesk.Revit.DB.Form.AddEdge Method

**中文**: 对话框、窗口、窗体

Add an edge to the form, connecting two edges on different profiles, by a specified face of the form and a point on face.

## Syntax (C#)
```csharp
public void AddEdge(
	Reference faceReference,
	XYZ point
)
```

## Parameters
- **faceReference** (`Autodesk.Revit.DB.Reference`) - The geometry reference of face
- **point** (`Autodesk.Revit.DB.XYZ`) - A point on the face, defining the position of edge to be created.

