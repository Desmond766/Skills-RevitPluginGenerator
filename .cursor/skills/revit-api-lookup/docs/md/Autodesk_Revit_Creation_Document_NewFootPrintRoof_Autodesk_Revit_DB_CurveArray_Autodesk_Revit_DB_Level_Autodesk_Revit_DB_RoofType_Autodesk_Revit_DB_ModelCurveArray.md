---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewFootPrintRoof(Autodesk.Revit.DB.CurveArray,Autodesk.Revit.DB.Level,Autodesk.Revit.DB.RoofType,Autodesk.Revit.DB.ModelCurveArray@)
zh: 文档、文件
source: html/110741bf-b041-9f78-0832-ec9f5892cebc.htm
---
# Autodesk.Revit.Creation.Document.NewFootPrintRoof Method

**中文**: 文档、文件

Creates a new FootPrintRoof element.

## Syntax (C#)
```csharp
public FootPrintRoof NewFootPrintRoof(
	CurveArray footPrint,
	Level level,
	RoofType roofType,
	out ModelCurveArray footPrintToModelCurvesMapping
)
```

## Parameters
- **footPrint** (`Autodesk.Revit.DB.CurveArray`) - The footprint of the FootPrintRoof.
- **level** (`Autodesk.Revit.DB.Level`) - The level of the FootPrintRoof.
- **roofType** (`Autodesk.Revit.DB.RoofType`) - Type of the FootPrintRoof.
- **footPrintToModelCurvesMapping** (`Autodesk.Revit.DB.ModelCurveArray %`) - An array of Model Curves corresponding to the set of Curves input in the footPrint. By knowing which Model Curve was created by each footPrint curve, you can set properties like SlopeAngle for each curve.

## Remarks
This method will regenerate the document even in manual regeneration mode.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the level does not exist in the given document.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the roof type does not exist in the given document.

