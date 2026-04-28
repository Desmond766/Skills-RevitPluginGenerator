---
kind: method
id: M:Autodesk.Revit.DB.Transform.CreateTranslation(Autodesk.Revit.DB.XYZ)
zh: 变换
source: html/b1a26f8c-1593-5b74-d78e-d4261ec5ebe5.htm
---
# Autodesk.Revit.DB.Transform.CreateTranslation Method

**中文**: 变换

Creates a transform that represents a translation via the specified vector.

## Syntax (C#)
```csharp
public static Transform CreateTranslation(
	XYZ vector
)
```

## Parameters
- **vector** (`Autodesk.Revit.DB.XYZ`) - The translation vector.

## Returns
The new transform.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL

