---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionGeneralC.#ctor(System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionAnalysisParams)
source: html/98b67dd3-9fd5-ea3a-b605-cef20adfc8a6.htm
---
# Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionGeneralC.#ctor Method

Creates a new instance of general Channel Cold Formed shape.

## Syntax (C#)
```csharp
public StructuralSectionGeneralC(
	double width,
	double height,
	double wallNominalThickness,
	double wallDesignThickness,
	double innerFillet,
	double lipLength,
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
- **lipLength** (`System.Double`) - Lip segment length.
- **centroidHorizontal** (`System.Double`) - Distance from centroid to the left extremites along horizontal axis.
- **centroidVertical** (`System.Double`) - Distance from centroid to the upper extremites along vertical axis.
- **analysisParams** (`Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionAnalysisParams`) - Common set of parameters for structural analysis.

