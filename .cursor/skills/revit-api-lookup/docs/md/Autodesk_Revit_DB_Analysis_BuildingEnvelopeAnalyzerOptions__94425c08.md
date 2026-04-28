---
kind: type
id: T:Autodesk.Revit.DB.Analysis.BuildingEnvelopeAnalyzerOptions
source: html/2a20b547-06bb-360c-c977-24466b56386a.htm
---
# Autodesk.Revit.DB.Analysis.BuildingEnvelopeAnalyzerOptions

Specific options for the method analyzing the building elements for the building envelope.

## Syntax (C#)
```csharp
public class BuildingEnvelopeAnalyzerOptions : IDisposable
```

## Remarks
The analyze method uses a combination of ray-casting and flood-fill
 algorithms in order to find the building elements that are
 exposed to the outside of the building.
 The analyze method can also look for the bounding building elements for
 enclosed space volumes inside the building.

