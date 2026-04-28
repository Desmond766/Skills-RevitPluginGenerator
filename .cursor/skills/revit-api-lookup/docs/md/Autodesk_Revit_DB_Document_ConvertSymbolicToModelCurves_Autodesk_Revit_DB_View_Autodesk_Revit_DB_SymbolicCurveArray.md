---
kind: method
id: M:Autodesk.Revit.DB.Document.ConvertSymbolicToModelCurves(Autodesk.Revit.DB.View,Autodesk.Revit.DB.SymbolicCurveArray)
zh: 文档、文件
source: html/f7f3a66a-d57a-a20e-d860-8e3a3f889566.htm
---
# Autodesk.Revit.DB.Document.ConvertSymbolicToModelCurves Method

**中文**: 文档、文件

Converts a group of SymbolicCurves to equivalent ModelCurves.

## Syntax (C#)
```csharp
public ModelCurveArray ConvertSymbolicToModelCurves(
	View view,
	SymbolicCurveArray symbolicCurve
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view where the new lines will be created.
The lines are projected on the view workplane.
The view workplane must be parallel to the view plane.
- **symbolicCurve** (`Autodesk.Revit.DB.SymbolicCurveArray`) - The symbolic curve array to be converted.

## Remarks
This operation will create new ModelCurves with the symbolicCurves' geometry curves and delete the SymbolicCurve in the array.

## Exceptions
- **System.ArgumentNullException** - Thrown when the input argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **System.InvalidOperationException** - Thrown when one or more curves could not be successfully converted.

