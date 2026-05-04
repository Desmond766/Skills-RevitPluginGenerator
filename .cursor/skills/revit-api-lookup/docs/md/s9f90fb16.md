---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionGeneralLA.#ctor(System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionAnalysisParams)
source: html/dde01d7e-6cc6-4850-bbb7-c677afb0778a.htm
---
# Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionGeneralLA.#ctor Method

Creates a new instance of Angle Cold Formed shape.

## Syntax (C#)
```csharp
public StructuralSectionGeneralLA(
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

