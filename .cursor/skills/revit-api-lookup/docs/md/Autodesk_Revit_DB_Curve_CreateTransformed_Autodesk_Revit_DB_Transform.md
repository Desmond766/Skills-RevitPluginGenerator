---
kind: method
id: M:Autodesk.Revit.DB.Curve.CreateTransformed(Autodesk.Revit.DB.Transform)
zh: 曲线
source: html/4f014114-64f7-fff1-f24f-bfc6e0cad82a.htm
---
# Autodesk.Revit.DB.Curve.CreateTransformed Method

**中文**: 曲线

Crates a new instance of a curve as a transformation of this curve.

## Syntax (C#)
```csharp
public Curve CreateTransformed(
	Transform transform
)
```

## Parameters
- **transform** (`Autodesk.Revit.DB.Transform`) - The transform to apply.

## Returns
The new curve.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - transform is not conformal.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL

