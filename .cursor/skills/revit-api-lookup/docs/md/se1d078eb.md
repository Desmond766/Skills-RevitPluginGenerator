---
kind: property
id: P:Autodesk.Revit.DB.Form.ProfileCurveLoopCount(System.Int32)
zh: 对话框、窗口、窗体
source: html/5ba5320b-8200-5d21-e5b2-2e08cb72c709.htm
---
# Autodesk.Revit.DB.Form.ProfileCurveLoopCount Property

**中文**: 对话框、窗口、窗体

The number of curve loops in certain profile, specified by profile index.

## Syntax (C#)
```csharp
public int this[
	int index
] { get; }
```

## Parameters
- **index** (`System.Int32`) - Index to specify the profile, should be within 0 and (ProfileCount - 1).

