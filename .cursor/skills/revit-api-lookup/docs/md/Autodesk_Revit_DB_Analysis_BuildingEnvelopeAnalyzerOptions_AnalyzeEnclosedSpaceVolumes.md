---
kind: property
id: P:Autodesk.Revit.DB.Analysis.BuildingEnvelopeAnalyzerOptions.AnalyzeEnclosedSpaceVolumes
source: html/bdc31f32-24ff-a963-b75f-e5c0b4a7ddc9.htm
---
# Autodesk.Revit.DB.Analysis.BuildingEnvelopeAnalyzerOptions.AnalyzeEnclosedSpaceVolumes Property

Whether or not to analyze interior connected regions inside the building forming enclosed space volumes.

## Syntax (C#)
```csharp
public bool AnalyzeEnclosedSpaceVolumes { get; set; }
```

## Remarks
If true, the analyzer will also look for bounding building elements and
 connected analytical grid cells for enclosed space volumes inside the building.

