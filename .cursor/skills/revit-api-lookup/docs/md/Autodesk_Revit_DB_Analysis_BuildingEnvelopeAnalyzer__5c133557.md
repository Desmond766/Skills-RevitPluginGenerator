---
kind: type
id: T:Autodesk.Revit.DB.Analysis.BuildingEnvelopeAnalyzer
source: html/7f7ccb3f-75e2-6e4d-021c-85718ea2f30b.htm
---
# Autodesk.Revit.DB.Analysis.BuildingEnvelopeAnalyzer

Analyzes which elements are part of the building envelope, the building elements exposed to the outside.

## Syntax (C#)
```csharp
public class BuildingEnvelopeAnalyzer : IDisposable
```

## Remarks
This class uses a combination of ray-casting and flood-fill
 algorithms in order to find the building elements that are
 exposed to the outside of the building.
 This method can also look for the bounding building elements for
 enclosed space volumes inside the building.

