---
kind: method
id: M:Autodesk.Revit.DB.Form.Rehost(Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.XYZ)
zh: 对话框、窗口、窗体
source: html/a222958c-4b12-075b-ade4-d78642c40d90.htm
---
# Autodesk.Revit.DB.Form.Rehost Method

**中文**: 对话框、窗口、窗体

Rehost Form to edge, face or curve.

## Syntax (C#)
```csharp
public void Rehost(
	Reference hostRef,
	XYZ location
)
```

## Parameters
- **hostRef** (`Autodesk.Revit.DB.Reference`) - The geometry reference on which to rehost the form.
- **location** (`Autodesk.Revit.DB.XYZ`) - The location to which to Rehost the form.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the hostRef or location is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when rehosting Form failed.

