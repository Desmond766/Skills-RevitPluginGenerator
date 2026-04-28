---
kind: method
id: M:Autodesk.Revit.DB.Transform.op_Multiply(Autodesk.Revit.DB.Transform,Autodesk.Revit.DB.Transform)
zh: 变换
source: html/d1ff39c4-3abd-f69c-d73d-c008b38f2d8c.htm
---
# Autodesk.Revit.DB.Transform.op_Multiply Method

**中文**: 变换

Multiplies the two specified transforms.

## Syntax (C#)
```csharp
public static Transform operator *(
	Transform left,
	Transform right
)
```

## Parameters
- **left** (`Autodesk.Revit.DB.Transform`) - The first transformation.
- **right** (`Autodesk.Revit.DB.Transform`) - The second transformation.

## Returns
The transformation equal to the composition of the two transformations.

## Remarks
The combined transformation has the same effect as applying the right transformation first, 
and the left transformation, second. So, (T1(T2(p)) = (T1 * T2) (p).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the handle of the first or second transformation is Nothing nullptr a null reference ( Nothing in Visual Basic) .

