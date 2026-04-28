---
kind: method
id: M:Autodesk.Revit.DB.Form.ScaleSubElement(Autodesk.Revit.DB.Reference,System.Double,Autodesk.Revit.DB.XYZ)
zh: 对话框、窗口、窗体
source: html/c6f922b5-2c99-c8f7-025e-1df81f4cc480.htm
---
# Autodesk.Revit.DB.Form.ScaleSubElement Method

**中文**: 对话框、窗口、窗体

Scale a face/edge/curve/vertex of the form, by a specified origin and scale factor.

## Syntax (C#)
```csharp
public void ScaleSubElement(
	Reference subElementReference,
	double factor,
	XYZ origin
)
```

## Parameters
- **subElementReference** (`Autodesk.Revit.DB.Reference`) - The geometry reference of face/edge/curve/vertex
- **factor** (`System.Double`) - The scale factor, it should be large than zero.
- **origin** (`Autodesk.Revit.DB.XYZ`) - The origin where scale happens.

