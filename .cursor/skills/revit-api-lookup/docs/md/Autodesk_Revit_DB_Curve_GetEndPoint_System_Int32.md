---
kind: method
id: M:Autodesk.Revit.DB.Curve.GetEndPoint(System.Int32)
zh: 曲线
source: html/a02da994-2976-38c0-e16b-20292de9fe57.htm
---
# Autodesk.Revit.DB.Curve.GetEndPoint Method

**中文**: 曲线

Returns the 3D point at the start or end of this curve.

## Syntax (C#)
```csharp
public XYZ GetEndPoint(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - 0 for the start or 1 for end of the curve.

## Returns
The curve endpoint.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - curve is unbound and does not have start and end points.
 -or-
 index must be 0 for the start of the curve or 1 for the end.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL

