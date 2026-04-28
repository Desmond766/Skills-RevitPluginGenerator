---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionGeneralW.#ctor(System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionAnalysisParams)
source: html/ae08d47c-ffae-aa01-d6e2-f4647a021205.htm
---
# Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionGeneralW.#ctor Method

Creates a new instance of Angle shape.

## Syntax (C#)
```csharp
public StructuralSectionGeneralW(
	double width,
	double height,
	double flangeThickness,
	double webThickness,
	double webFillet,
	double flangeFillet,
	double topWebFillet,
	double centroidHorizontal,
	double centroidVertical,
	StructuralSectionAnalysisParams analysisParams
)
```

## Parameters
- **width** (`System.Double`) - Section width.
- **height** (`System.Double`) - Section height, depth.
- **flangeThickness** (`System.Double`) - Flange Thickness.
- **webThickness** (`System.Double`) - Web Thickness.
- **webFillet** (`System.Double`) - Web Fillet - fillet radius between web and flange.
- **flangeFillet** (`System.Double`) - Flange Fillet - fillet radius at the flange end.
- **topWebFillet** (`System.Double`) - Top Web Fillet - fillet radius at the top of web.
- **centroidHorizontal** (`System.Double`) - Distance from centroid to the left extremites along horizontal axis.
- **centroidVertical** (`System.Double`) - Distance from centroid to the upper extremites along vertical axis.
- **analysisParams** (`Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionAnalysisParams`) - Common set of parameters for structural analysis.

