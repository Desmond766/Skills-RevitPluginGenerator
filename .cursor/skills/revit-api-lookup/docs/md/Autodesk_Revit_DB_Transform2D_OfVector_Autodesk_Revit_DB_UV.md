---
kind: method
id: M:Autodesk.Revit.DB.Transform2D.OfVector(Autodesk.Revit.DB.UV)
source: html/72a66105-55d1-3930-8934-2d46d5dd064d.htm
---
# Autodesk.Revit.DB.Transform2D.OfVector Method

Applies the transformation to the vector and returns the result.

## Syntax (C#)
```csharp
public UV OfVector(
	UV vector
)
```

## Parameters
- **vector** (`Autodesk.Revit.DB.UV`) - The vector to transform.

## Returns
The transformed vector.

## Remarks
Transformation of a vector is not affected by the translational part of the transformation.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

