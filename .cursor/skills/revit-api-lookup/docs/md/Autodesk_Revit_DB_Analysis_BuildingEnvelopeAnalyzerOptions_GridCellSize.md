---
kind: property
id: P:Autodesk.Revit.DB.Analysis.BuildingEnvelopeAnalyzerOptions.GridCellSize
source: html/42067248-49bc-e1e7-ca82-0cfddda08cbe.htm
---
# Autodesk.Revit.DB.Analysis.BuildingEnvelopeAnalyzerOptions.GridCellSize Property

The cell size for the uniform cubical grid used when analyzing the building envelope.

## Syntax (C#)
```csharp
public double GridCellSize { get; set; }
```

## Remarks
This is the base size of the "cubes" used to divide the building shell
 bounding box into a uniform cubical 3D grid. If this overrideGridCellSize option is set,
 this exact value will be used for the grid cell size. The cell size should be specified in
 the length unit for the Revit project.

