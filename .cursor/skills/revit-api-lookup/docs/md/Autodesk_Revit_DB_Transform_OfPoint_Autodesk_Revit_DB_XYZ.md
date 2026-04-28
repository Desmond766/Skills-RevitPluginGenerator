---
kind: method
id: M:Autodesk.Revit.DB.Transform.OfPoint(Autodesk.Revit.DB.XYZ)
zh: 变换
source: html/55c834aa-ef75-f6f1-4c89-d908d842e9d6.htm
---
# Autodesk.Revit.DB.Transform.OfPoint Method

**中文**: 变换

Applies the transformation to the point and returns the result.

## Syntax (C#)
```csharp
public XYZ OfPoint(
	XYZ point
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.XYZ`) - The point to transform.

## Returns
The transformed point.

## Remarks
Transformation of a point is affected by the translational part of the transformation.

