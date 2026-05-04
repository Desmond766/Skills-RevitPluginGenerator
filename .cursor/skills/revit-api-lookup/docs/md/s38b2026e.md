---
kind: method
id: M:Autodesk.Revit.DB.Form.ScaleProfile(System.Int32,System.Double,Autodesk.Revit.DB.XYZ)
zh: 对话框、窗口、窗体
source: html/51b12c40-3f05-3c5a-acd1-23b017bbff1b.htm
---
# Autodesk.Revit.DB.Form.ScaleProfile Method

**中文**: 对话框、窗口、窗体

Scale a profile of the form, by a specified origin and scale factor.

## Syntax (C#)
```csharp
public void ScaleProfile(
	int profileIndex,
	double factor,
	XYZ origin
)
```

## Parameters
- **profileIndex** (`System.Int32`) - Index to specify the profile.
- **factor** (`System.Double`) - The scale factor, it should be large than zero.
- **origin** (`Autodesk.Revit.DB.XYZ`) - The origin where scale happens.

