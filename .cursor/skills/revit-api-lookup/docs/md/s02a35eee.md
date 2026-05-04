---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionGeneralU.#ctor(System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionAnalysisParams)
source: html/c9096137-b748-73e7-71a1-5342202dc7f7.htm
---
# Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionGeneralU.#ctor Method

Creates a new instance of general Channel shape.

## Syntax (C#)
```csharp
public StructuralSectionGeneralU(
	double width,
	double height,
	double flangeThickness,
	double flangeThicknessLocation,
	double flangeFillet,
	double flangeToeOfFillet,
	double slopedFlangeAngle,
	double webThickness,
	double webFillet,
	double webToeOfFillet,
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
- **webFillet** (`System.Double`) - Web Fillet - fillet radius between web and flange.
- **webToeOfFillet** (`System.Double`) - Detailing distance from outer face of flange to web toe of fillet, in. (mm)
- **centroidHorizontal** (`System.Double`) - Distance from centroid to the left extremites along horizontal axis.
- **centroidVertical** (`System.Double`) - Distance from centroid to the upper extremites along vertical axis.
- **analysisParams** (`Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionAnalysisParams`) - Common set of parameters for structural analysis.

