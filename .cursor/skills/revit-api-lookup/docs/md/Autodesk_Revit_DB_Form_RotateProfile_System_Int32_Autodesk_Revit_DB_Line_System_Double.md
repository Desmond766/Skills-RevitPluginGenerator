---
kind: method
id: M:Autodesk.Revit.DB.Form.RotateProfile(System.Int32,Autodesk.Revit.DB.Line,System.Double)
zh: 对话框、窗口、窗体
source: html/2a6908b6-f1ea-aa45-9890-2e5699635de6.htm
---
# Autodesk.Revit.DB.Form.RotateProfile Method

**中文**: 对话框、窗口、窗体

Rotate a profile of the form, by a specified angle around a given axis.

## Syntax (C#)
```csharp
public void RotateProfile(
	int profileIndex,
	Line axis,
	double angle
)
```

## Parameters
- **profileIndex** (`System.Int32`) - Index to specify the profile.
- **axis** (`Autodesk.Revit.DB.Line`) - An unbounded line that represents the axis of rotation.
- **angle** (`System.Double`) - The angle, in radians, by which the element is to be rotated around the specified axis.

