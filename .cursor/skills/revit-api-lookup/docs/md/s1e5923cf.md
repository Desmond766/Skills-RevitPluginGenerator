---
kind: property
id: P:Autodesk.Revit.DB.Analysis.BuildingEnvelopeAnalyzerOptions.OptimizeGridCellSize
source: html/b1eb1927-00ce-572e-a500-ef06f40ecd50.htm
---
# Autodesk.Revit.DB.Analysis.BuildingEnvelopeAnalyzerOptions.OptimizeGridCellSize Property

Whether or not to use the exact value for the cell size or let the analyzer optimize the cell size based on the specified grid size

## Syntax (C#)
```csharp
public bool OptimizeGridCellSize { get; set; }
```

## Remarks
If this option is true, the analyzer will decide the optimal cell size for the uniform cubical grid used
 when computing the building envelope. The optimal cell size is based on the specified cell size,
 but can be higher. If this option is false, the exact specified grid cell size will be used.

