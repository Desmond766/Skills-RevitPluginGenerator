---
kind: method
id: M:Autodesk.Revit.DB.Form.RotateSubElement(Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.Line,System.Double)
zh: 对话框、窗口、窗体
source: html/e8be996f-6174-64b5-938b-ddf0818dd81d.htm
---
# Autodesk.Revit.DB.Form.RotateSubElement Method

**中文**: 对话框、窗口、窗体

Rotate a face/edge/curve/vertex of the form, by a specified angle around a given axis.

## Syntax (C#)
```csharp
public void RotateSubElement(
	Reference subElementReference,
	Line axis,
	double angle
)
```

## Parameters
- **subElementReference** (`Autodesk.Revit.DB.Reference`) - The geometry reference of face/edge/curve/vertex
- **axis** (`Autodesk.Revit.DB.Line`) - An unbounded line that represents the axis of rotation.
- **angle** (`System.Double`) - The angle, in radians, by which the element is to be rotated around the specified axis.

