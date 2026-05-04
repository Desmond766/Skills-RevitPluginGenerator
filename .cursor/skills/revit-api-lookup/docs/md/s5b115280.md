---
kind: method
id: M:Autodesk.Revit.DB.SolidUtils.CreateTransformed(Autodesk.Revit.DB.Solid,Autodesk.Revit.DB.Transform)
source: html/22592761-f39c-4f53-d33b-6c21a4fa9d2d.htm
---
# Autodesk.Revit.DB.SolidUtils.CreateTransformed Method

Creates a new Solid which is the transformation of the input Solid.

## Syntax (C#)
```csharp
public static Solid CreateTransformed(
	Solid solid,
	Transform transform
)
```

## Parameters
- **solid** (`Autodesk.Revit.DB.Solid`) - The input solid to be transformed.
- **transform** (`Autodesk.Revit.DB.Transform`) - The transform (which must be conformal).

## Returns
The newly created Solid.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - transform is not conformal.
 -or-
 transform has a scale that is negative or zero.

