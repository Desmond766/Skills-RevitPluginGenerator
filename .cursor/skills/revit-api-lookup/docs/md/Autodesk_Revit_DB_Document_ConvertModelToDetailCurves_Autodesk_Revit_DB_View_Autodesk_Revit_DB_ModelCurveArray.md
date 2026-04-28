---
kind: method
id: M:Autodesk.Revit.DB.Document.ConvertModelToDetailCurves(Autodesk.Revit.DB.View,Autodesk.Revit.DB.ModelCurveArray)
zh: 文档、文件
source: html/5566ffcf-1724-589b-15a1-6e829a986ec2.htm
---
# Autodesk.Revit.DB.Document.ConvertModelToDetailCurves Method

**中文**: 文档、文件

Converts a group of ModelCurves to equivalent DetailCurves.

## Syntax (C#)
```csharp
public DetailCurveArray ConvertModelToDetailCurves(
	View view,
	ModelCurveArray modelCurves
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view where the new lines will be created. 
The lines are projected on the view plane.
If the lines are not parallel to the view plane, lines are foreshortened and arcs are converted to ellipses.
Splines are modified.
- **modelCurves** (`Autodesk.Revit.DB.ModelCurveArray`) - The model curve array to be converted.

## Remarks
This operation will create new DetailCurves with the same geometry of the original model curves' geometry. The model curves will be deleted from the document. 
If the model curves do not lie in a plane parallel to the view, their geometry will be projected to the view.

## Exceptions
- **System.ArgumentNullException** - Thrown when the input argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **System.ArgumentException** - Thrown when view is invalid to create DetailCurves on it.
- **System.InvalidOperationException** - Thrown when current document is a family.
Thrown when one or more curves could not be successfully converted, perhaps because some of the input curves could not be projected onto the active workplane of the view.

