---
kind: method
id: M:Autodesk.Revit.Creation.ItemFactoryBase.NewModelCurve(Autodesk.Revit.DB.Curve,Autodesk.Revit.DB.SketchPlane)
source: html/b880c4d7-9841-e44e-2a1c-36fefe274e2e.htm
---
# Autodesk.Revit.Creation.ItemFactoryBase.NewModelCurve Method

Creates a new model line element.

## Syntax (C#)
```csharp
public ModelCurve NewModelCurve(
	Curve geometryCurve,
	SketchPlane sketchPlane
)
```

## Parameters
- **geometryCurve** (`Autodesk.Revit.DB.Curve`) - The internal geometry curve for model line.
- **sketchPlane** (`Autodesk.Revit.DB.SketchPlane`) - The sketch plane this new model line resides in.

## Returns
If successful a new model line element. Otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Remarks
Different type of model curve element will be returned according to the type of geometry curve.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when curve is not in the plane

