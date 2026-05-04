---
kind: method
id: M:Autodesk.Revit.Creation.ItemFactoryBase.NewDetailCurveArray(Autodesk.Revit.DB.View,Autodesk.Revit.DB.CurveArray)
source: html/fa64b91f-d0ff-6793-1fc5-05ca1204a9c5.htm
---
# Autodesk.Revit.Creation.ItemFactoryBase.NewDetailCurveArray Method

Creates an array of new detail curve elements.

## Syntax (C#)
```csharp
public DetailCurveArray NewDetailCurveArray(
	View view,
	CurveArray geometryCurveArray
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view in which the detail curves are to be visible.
- **geometryCurveArray** (`Autodesk.Revit.DB.CurveArray`) - An array containing the internal geometry curves for detail lines.
 The curve in array should be bound curve.

## Returns
If successful an array of new detail curve elements. Otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when curve is not in plane of the view

