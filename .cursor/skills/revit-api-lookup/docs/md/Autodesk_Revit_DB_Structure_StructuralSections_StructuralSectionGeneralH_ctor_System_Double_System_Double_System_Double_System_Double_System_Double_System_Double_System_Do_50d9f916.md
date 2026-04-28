---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionGeneralH.#ctor(System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionAnalysisParams)
source: html/ff63e780-3232-1413-8a87-d451a7292503.htm
---
# Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionGeneralH.#ctor Method

Creates a new instance of Rectangular Pipe shape.

## Syntax (C#)
```csharp
public StructuralSectionGeneralH(
	double width,
	double height,
	double wallNominalThickness,
	double wallDesignThickness,
	double innerFillet,
	double outerFillet,
	double centroidHorizontal,
	double centroidVertical,
	StructuralSectionAnalysisParams analysisParams
)
```

## Parameters
- **width** (`System.Double`) - Section width.
- **height** (`System.Double`) - Section height, depth.
- **wallNominalThickness** (`System.Double`) - Represents wall nominal thickness of rectangle.
- **wallDesignThickness** (`System.Double`) - Represents wall design thickness of rectangle.
- **innerFillet** (`System.Double`) - Inner Fillet - Corner fillet inner radius.
- **outerFillet** (`System.Double`) - Outer Fillet - Corner fillet outer radius.
- **centroidHorizontal** (`System.Double`) - Distance from centroid to the left extremites along horizontal axis.
- **centroidVertical** (`System.Double`) - Distance from centroid to the upper extremites along vertical axis.
- **analysisParams** (`Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionAnalysisParams`) - Common set of parameters for structural analysis.

