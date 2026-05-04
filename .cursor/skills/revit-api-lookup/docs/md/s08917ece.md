---
kind: method
id: M:Autodesk.Revit.DB.Document.ConvertModelToSymbolicCurves(Autodesk.Revit.DB.View,Autodesk.Revit.DB.ModelCurveArray)
zh: 文档、文件
source: html/ee3b6765-5af9-acd8-5132-42484ab20924.htm
---
# Autodesk.Revit.DB.Document.ConvertModelToSymbolicCurves Method

**中文**: 文档、文件

Converts a group of ModelCurves to equivalent SymbolicCurves.

## Syntax (C#)
```csharp
public SymbolicCurveArray ConvertModelToSymbolicCurves(
	View view,
	ModelCurveArray modelCurves
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view where the new lines will be created. 
The lines are projected on the view workplane.
The view workplane must be parallel to the view plane.
If the lines are not parallel to the view plane, lines are foreshortened and arcs are converted to ellipses.
Splines are modified.
- **modelCurves** (`Autodesk.Revit.DB.ModelCurveArray`) - The model curve array to be converted.

## Remarks
This operation will create new SymbolicCurves with the modelCurves' geometry curves and delete the ModelCurve in the array.
If modelCurves are not parallel to the workplane, they will be projected to the workplane and create new SymbolicCurves with the projected curves.

## Exceptions
- **System.ArgumentNullException** - Thrown when the input argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **System.ArgumentException** - Thrown when view is invalid to create SymbolicCurves on it.
- **System.InvalidOperationException** - Thrown when current document is a family.
 Thrown when one or more curves could not be successfully converted, perhaps because some of the input curves could not be projected onto the active workplane of the view.

