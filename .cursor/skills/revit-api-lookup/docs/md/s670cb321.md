---
kind: property
id: P:Autodesk.Revit.DB.Form.CurveLoopReferencesOnProfile(System.Int32,System.Int32)
zh: 对话框、窗口、窗体
source: html/89c48f40-ccec-5acd-f165-06b01004e80f.htm
---
# Autodesk.Revit.DB.Form.CurveLoopReferencesOnProfile Property

**中文**: 对话框、窗口、窗体

The curve references in certain curve loop, specified by profile index and curve loop index.

## Syntax (C#)
```csharp
public ReferenceArray this[
	int profileIndex,
	int curveLoopIndex
] { get; }
```

## Parameters
- **profileIndex** (`System.Int32`) - Index to specify the profile, should be within 0 and (ProfileCount - 1).
- **curveLoopIndex** (`System.Int32`) - Index to specify the curve loop, should be within 0 and (CurveLoopCount - 1).

