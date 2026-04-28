---
kind: method
id: M:Autodesk.Revit.DB.Form.MoveSubElement(Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.XYZ)
zh: 对话框、窗口、窗体
source: html/d925ab62-52a9-d161-a4f6-56386b5177a3.htm
---
# Autodesk.Revit.DB.Form.MoveSubElement Method

**中文**: 对话框、窗口、窗体

Move a face/edge/curve/vertex of the form, specified by a reference, and an offset vector.

## Syntax (C#)
```csharp
public void MoveSubElement(
	Reference subElementReference,
	XYZ offset
)
```

## Parameters
- **subElementReference** (`Autodesk.Revit.DB.Reference`) - The geometry reference of face/edge/curve/vertex
- **offset** (`Autodesk.Revit.DB.XYZ`) - The vector by which the element is to be moved.

