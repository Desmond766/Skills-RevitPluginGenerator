---
kind: method
id: M:Autodesk.Revit.DB.Form.Rehost(Autodesk.Revit.DB.SketchPlane,Autodesk.Revit.DB.XYZ)
zh: 对话框、窗口、窗体
source: html/80d96216-f5fd-0aa7-954b-33b7b0ddcf9b.htm
---
# Autodesk.Revit.DB.Form.Rehost Method

**中文**: 对话框、窗口、窗体

Rehost Form to sketch plane

## Syntax (C#)
```csharp
public void Rehost(
	SketchPlane sketchPlane,
	XYZ location
)
```

## Parameters
- **sketchPlane** (`Autodesk.Revit.DB.SketchPlane`) - The sketch plane on which to rehost the form.
- **location** (`Autodesk.Revit.DB.XYZ`) - The location to which to Rehost the form.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the sketchPlane or location is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when rehosting Form failed.

