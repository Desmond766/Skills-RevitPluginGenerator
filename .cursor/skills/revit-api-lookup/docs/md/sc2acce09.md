---
kind: method
id: M:Autodesk.Revit.DB.Form.GetProfileAndCurveLoopIndexFromReference(Autodesk.Revit.DB.Reference,System.Int32@,System.Int32@)
zh: 对话框、窗口、窗体
source: html/995e6f14-0e79-e21b-120b-2b4644f622c8.htm
---
# Autodesk.Revit.DB.Form.GetProfileAndCurveLoopIndexFromReference Method

**中文**: 对话框、窗口、窗体

Given a reference to certain curve or edge, get the index of its profile and curve loop respectively.

## Syntax (C#)
```csharp
public void GetProfileAndCurveLoopIndexFromReference(
	Reference curveOrEdgeReference,
	ref int profileIndex,
	ref int curveLoopIndex
)
```

## Parameters
- **curveOrEdgeReference** (`Autodesk.Revit.DB.Reference`) - Reference to a curve/edge that is part of one profile
- **profileIndex** (`System.Int32 %`) - Profile index for output
- **curveLoopIndex** (`System.Int32 %`) - Curve loop index for output

