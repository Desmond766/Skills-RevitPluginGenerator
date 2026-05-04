---
kind: method
id: M:Autodesk.Revit.Creation.ItemFactoryBase.NewModelCurveArray(Autodesk.Revit.DB.CurveArray,Autodesk.Revit.DB.SketchPlane)
source: html/12beb77b-e5fe-1499-7da3-78742dba3303.htm
---
# Autodesk.Revit.Creation.ItemFactoryBase.NewModelCurveArray Method

Creates an array of new model line elements.

## Syntax (C#)
```csharp
public ModelCurveArray NewModelCurveArray(
	CurveArray geometryCurveArray,
	SketchPlane sketchPlane
)
```

## Parameters
- **geometryCurveArray** (`Autodesk.Revit.DB.CurveArray`) - An array containing the internal geometry curves for model lines.
- **sketchPlane** (`Autodesk.Revit.DB.SketchPlane`)

## Returns
If successful an array of new model line elements. Otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Remarks
Exceptions Exception Condition Autodesk.Revit.Exceptions.ArgumentException Thrown when curve is not in the plane

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when curve is not in the plane

