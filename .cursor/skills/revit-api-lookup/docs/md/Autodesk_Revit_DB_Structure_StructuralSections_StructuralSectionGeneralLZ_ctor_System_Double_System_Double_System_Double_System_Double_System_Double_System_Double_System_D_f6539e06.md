---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionGeneralLZ.#ctor(System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionAnalysisParams)
source: html/4284623a-86c6-68e7-d190-7f85f49fc855.htm
---
# Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionGeneralLZ.#ctor Method

Creates a new instance of Z Cold Formed shape.

## Syntax (C#)
```csharp
public StructuralSectionGeneralLZ(
	double width,
	double height,
	double wallNominalThickness,
	double wallDesignThickness,
	double innerFillet,
	double bottomFlangeLength,
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
- **bottomFlangeLength** (`System.Double`) - Bottom Flange segment length.
- **lipLength** (`System.Double`) - Lip segment length.
- **centroidHorizontal** (`System.Double`) - Distance from centroid to the left extremites along horizontal axis.
- **centroidVertical** (`System.Double`) - Distance from centroid to the upper extremites along vertical axis.
- **analysisParams** (`Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionAnalysisParams`) - Common set of parameters for structural analysis.

