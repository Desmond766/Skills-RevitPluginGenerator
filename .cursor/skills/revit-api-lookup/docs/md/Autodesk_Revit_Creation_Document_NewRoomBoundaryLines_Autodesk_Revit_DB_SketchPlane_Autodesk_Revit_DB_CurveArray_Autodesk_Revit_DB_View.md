---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewRoomBoundaryLines(Autodesk.Revit.DB.SketchPlane,Autodesk.Revit.DB.CurveArray,Autodesk.Revit.DB.View)
zh: 文档、文件
source: html/cd40f8d3-e6cf-355e-d3c4-b3296e261485.htm
---
# Autodesk.Revit.Creation.Document.NewRoomBoundaryLines Method

**中文**: 文档、文件

Creates a new boundary line as an Room border.

## Syntax (C#)
```csharp
public ModelCurveArray NewRoomBoundaryLines(
	SketchPlane sketchPlane,
	CurveArray curves,
	View view
)
```

## Parameters
- **sketchPlane** (`Autodesk.Revit.DB.SketchPlane`) - The sketch plan
- **curves** (`Autodesk.Revit.DB.CurveArray`) - The geometry curves on which the boundary lines are
- **view** (`Autodesk.Revit.DB.View`) - The View for the new Room

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the sketch plane does not exist in the given document.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the view does not exist in the given document.

