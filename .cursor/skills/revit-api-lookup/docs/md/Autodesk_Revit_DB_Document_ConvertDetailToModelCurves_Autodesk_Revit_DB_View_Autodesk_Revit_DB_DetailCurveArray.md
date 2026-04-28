---
kind: method
id: M:Autodesk.Revit.DB.Document.ConvertDetailToModelCurves(Autodesk.Revit.DB.View,Autodesk.Revit.DB.DetailCurveArray)
zh: 文档、文件
source: html/4620e606-df11-67c6-a386-ade6fbb9911a.htm
---
# Autodesk.Revit.DB.Document.ConvertDetailToModelCurves Method

**中文**: 文档、文件

Converts a group of DetailCurves to equivalent ModelCurves.

## Syntax (C#)
```csharp
public ModelCurveArray ConvertDetailToModelCurves(
	View view,
	DetailCurveArray detailCurves
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view where the new lines will be created.
The lines are projected on the view workplane.
The view workplane must be parallel to the view plane.
- **detailCurves** (`Autodesk.Revit.DB.DetailCurveArray`) - The detail curve array to be converted.

## Remarks
This operation will create new ModelCurves with the same geometry of the original detail curves' geometry. The detail curves will be deleted from the document.

## Exceptions
- **System.ArgumentNullException** - Thrown when the input argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **System.ArgumentException** - Thrown when the given detail lines are not visible in the given view.
 Thrown when the detail lines are not in the same view or not parallel to the given view.
- **System.InvalidOperationException** - Thrown when one or more curves could not be successfully converted.

