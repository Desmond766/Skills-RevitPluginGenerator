---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionGeneralT.#ctor(System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionAnalysisParams)
source: html/3d55db12-8517-135f-1a63-9a1446c64480.htm
---
# Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionGeneralT.#ctor Method

Creates a new instance of Tees shape.

## Syntax (C#)
```csharp
public StructuralSectionGeneralT(
	double width,
	double height,
	double flangeThickness,
	double flangeThicknessLocation,
	double flangeFillet,
	double flangeToeOfFillet,
	double slopedFlangeAngle,
	double webThickness,
	double webThicknessLocation,
	double webFillet,
	double topWebFillet,
	double webToeOfFillet,
	double slopedWebAngle,
	double centroidHorizontal,
	double centroidVertical,
	StructuralSectionAnalysisParams analysisParams
)
```

## Parameters
- **width** (`System.Double`) - Section width.
- **height** (`System.Double`) - Section height, depth.
- **flangeThickness** (`System.Double`) - Flange Thickness.
- **flangeThicknessLocation** (`System.Double`) - Flange Thickness Location.
- **flangeFillet** (`System.Double`) - Flange Fillet - fillet radius at the flange end.
- **flangeToeOfFillet** (`System.Double`) - Detailing distance from center of web to flange toe of fillet, in. (mm)
- **slopedFlangeAngle** (`System.Double`) - Sloped flange angle. (rad)
- **webThickness** (`System.Double`) - Web Thickness.
- **webThicknessLocation** (`System.Double`) - Web Thickness Location.
- **webFillet** (`System.Double`) - Web Fillet - fillet radius between web and flange.
- **topWebFillet** (`System.Double`) - Top Web Fillet - fillet radius at the top of web.
- **webToeOfFillet** (`System.Double`) - Detailing distance from outer face of flange to web toe of fillet, in. (mm)
- **slopedWebAngle** (`System.Double`) - Sloped web angle. (rad)
- **centroidHorizontal** (`System.Double`) - Distance from centroid to the left extremites along horizontal axis.
- **centroidVertical** (`System.Double`) - Distance from centroid to the upper extremites along vertical axis.
- **analysisParams** (`Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionAnalysisParams`) - Common set of parameters for structural analysis.

