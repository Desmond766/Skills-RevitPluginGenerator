---
kind: method
id: M:Autodesk.Revit.DB.Transform.OfVector(Autodesk.Revit.DB.XYZ)
zh: 变换
source: html/4d5b7075-1b79-639d-5da2-eb23372bc888.htm
---
# Autodesk.Revit.DB.Transform.OfVector Method

**中文**: 变换

Applies the transform to the vector

## Syntax (C#)
```csharp
public XYZ OfVector(
	XYZ vec
)
```

## Parameters
- **vec** (`Autodesk.Revit.DB.XYZ`) - The vector to be transformed

## Returns
The new vector after transform

## Remarks
Transformation of a vector is not affected by the translational part of the transformation.

