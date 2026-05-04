---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewAreaBoundaryLine(Autodesk.Revit.DB.SketchPlane,Autodesk.Revit.DB.Curve,Autodesk.Revit.DB.ViewPlan)
zh: 文档、文件
source: html/0a905433-bd87-58d5-903b-344c47ad2519.htm
---
# Autodesk.Revit.Creation.Document.NewAreaBoundaryLine Method

**中文**: 文档、文件

Creates a new boundary line as an Area border.

## Syntax (C#)
```csharp
public ModelCurve NewAreaBoundaryLine(
	SketchPlane sketchPlane,
	Curve geometryCurve,
	ViewPlan areaView
)
```

## Parameters
- **sketchPlane** (`Autodesk.Revit.DB.SketchPlane`) - The sketch plane.
- **geometryCurve** (`Autodesk.Revit.DB.Curve`) - The geometry curve on which the boundary line are
- **areaView** (`Autodesk.Revit.DB.ViewPlan`) - The View for the new Area

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the sketch plane does not exist in the given document.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the area view does not exist in the given document.

