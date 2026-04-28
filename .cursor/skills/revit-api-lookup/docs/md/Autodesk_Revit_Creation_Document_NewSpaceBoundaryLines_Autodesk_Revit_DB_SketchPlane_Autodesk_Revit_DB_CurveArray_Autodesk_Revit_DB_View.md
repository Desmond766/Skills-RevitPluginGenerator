---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewSpaceBoundaryLines(Autodesk.Revit.DB.SketchPlane,Autodesk.Revit.DB.CurveArray,Autodesk.Revit.DB.View)
zh: 文档、文件
source: html/e95433bf-3440-50e3-c9d0-c5559fbb0aff.htm
---
# Autodesk.Revit.Creation.Document.NewSpaceBoundaryLines Method

**中文**: 文档、文件

Creates a new boundary line as an Space border.

## Syntax (C#)
```csharp
public ModelCurveArray NewSpaceBoundaryLines(
	SketchPlane sketchPlane,
	CurveArray curves,
	View view
)
```

## Parameters
- **sketchPlane** (`Autodesk.Revit.DB.SketchPlane`) - The sketch plan
- **curves** (`Autodesk.Revit.DB.CurveArray`) - The geometry curves on which the boundary lines are
- **view** (`Autodesk.Revit.DB.View`) - The View for the new Space

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the sketch plane does not exist in the given document.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the view does not exist in the given document.

