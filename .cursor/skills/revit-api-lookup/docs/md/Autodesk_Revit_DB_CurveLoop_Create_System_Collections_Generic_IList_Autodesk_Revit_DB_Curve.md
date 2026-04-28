---
kind: method
id: M:Autodesk.Revit.DB.CurveLoop.Create(System.Collections.Generic.IList{Autodesk.Revit.DB.Curve})
zh: 创建、新建、生成、建立、新增
source: html/5422ec92-2b9e-6b33-80ac-417b8336ae18.htm
---
# Autodesk.Revit.DB.CurveLoop.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new curve loop.

## Syntax (C#)
```csharp
public static CurveLoop Create(
	IList<Curve> curves
)
```

## Parameters
- **curves** (`System.Collections.Generic.IList < Curve >`) - The curves.

## Returns
The curve loop.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input curves contains at least one helical curve and is not supported for this operation.
 -or-
 Throws if the input curves are not contiguous.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

