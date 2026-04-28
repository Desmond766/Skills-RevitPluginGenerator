---
kind: method
id: M:Autodesk.Revit.DB.CurveUV.Transform(Autodesk.Revit.DB.Transform2D)
zh: 变换
source: html/628d9276-4912-58c8-8601-5f6b5266158c.htm
---
# Autodesk.Revit.DB.CurveUV.Transform Method

**中文**: 变换

Transform this CurveUV by the given 2D affine transform if possible.

## Syntax (C#)
```csharp
public CurveUV Transform(
	Transform2D trfUV
)
```

## Parameters
- **trfUV** (`Autodesk.Revit.DB.Transform2D`) - The given 2D affine transform.

## Returns
If successful a transformed CurveUV, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

