---
kind: method
id: M:Autodesk.Revit.Creation.ItemFactoryBase.NewDetailCurve(Autodesk.Revit.DB.View,Autodesk.Revit.DB.Curve)
source: html/9a8bd0d3-00dc-7a1c-39dd-e891899764ce.htm
---
# Autodesk.Revit.Creation.ItemFactoryBase.NewDetailCurve Method

Creates a new detail curve element.

## Syntax (C#)
```csharp
public DetailCurve NewDetailCurve(
	View view,
	Curve geometryCurve
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view in which the detail curve is to be visible.
- **geometryCurve** (`Autodesk.Revit.DB.Curve`) - The internal geometry curve for detail curve. It should be a bound curve.

## Returns
If successful a new detail curve element. Otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Remarks
Different type of detail curve element will be returned according to the type of geometry curve.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when curve is not in plane of the view

