---
kind: method
id: M:Autodesk.Revit.DB.CurveUV.Create(Autodesk.Revit.DB.Curve)
zh: 创建、新建、生成、建立、新增
source: html/64c3ccbc-ae7d-e9a8-d487-aab04f6143a5.htm
---
# Autodesk.Revit.DB.CurveUV.Create Method

**中文**: 创建、新建、生成、建立、新增

Create a CurveUV from a bounded 3D Curve lying in the XY plane.

## Syntax (C#)
```csharp
public static CurveUV Create(
	Curve curve3D
)
```

## Parameters
- **curve3D** (`Autodesk.Revit.DB.Curve`) - The input bounded 3D Curve lying in the XY plane (i.e., z = 0 everywhere along the curve).

## Returns
The newly created CurveUV.

## Remarks
The XY plane is identified with the uv parameter space of the surface to which this SurfParamSpaceCurve refers.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input Curve is not a bounded 3D Curve lying in the XY plane (i.e., z = 0 everywhere along the curve).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

