---
kind: method
id: M:Autodesk.Revit.DB.Transform2D.OfPoint(Autodesk.Revit.DB.UV)
source: html/083f5a56-31c6-e8b7-dc22-cf0f4c25608a.htm
---
# Autodesk.Revit.DB.Transform2D.OfPoint Method

Applies the transformation to the point and returns the result.

## Syntax (C#)
```csharp
public UV OfPoint(
	UV point
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.UV`) - The point to transform.

## Returns
The transformed point.

## Remarks
Transformation of a point is affected by the translational part of the transformation.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

