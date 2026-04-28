---
kind: method
id: M:Autodesk.Revit.DB.CurveLoop.CreateViaTransform(Autodesk.Revit.DB.CurveLoop,Autodesk.Revit.DB.Transform)
source: html/050e66f2-9202-ef95-2723-f19d8f4dcf5b.htm
---
# Autodesk.Revit.DB.CurveLoop.CreateViaTransform Method

Creates a new curve loop as a transformed copy of the input curve loop.

## Syntax (C#)
```csharp
public static CurveLoop CreateViaTransform(
	CurveLoop curveLoop,
	Transform transform
)
```

## Parameters
- **curveLoop** (`Autodesk.Revit.DB.CurveLoop`) - The input curve loop.
- **transform** (`Autodesk.Revit.DB.Transform`) - The transformation.

## Returns
The new curve loop.

## Remarks
The newly created CurveLoop is guaranteed to be valid with all consituent curves contiguous (assuming
 that the curves were contiguous in the input curve loop).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - transform is not conformal.
 -or-
 transform has a scale that is negative or zero.

