---
kind: method
id: M:Autodesk.Revit.DB.CurveLoop.Transform(Autodesk.Revit.DB.Transform)
zh: 变换
source: html/01e7c70f-9458-128f-b6bc-84acfd658dc5.htm
---
# Autodesk.Revit.DB.CurveLoop.Transform Method

**中文**: 变换

Transforms this curve loop and all of its component curves by the supplied transformation.

## Syntax (C#)
```csharp
public void Transform(
	Transform transform
)
```

## Parameters
- **transform** (`Autodesk.Revit.DB.Transform`) - The transformation.

## Remarks
The modified CurveLoop is guaranteed to be valid with all consituent curves contiguous (assuming
 that the curves were contiguous in the input curve loop).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - transform is not conformal.
 -or-
 transform has a scale that is negative or zero.

