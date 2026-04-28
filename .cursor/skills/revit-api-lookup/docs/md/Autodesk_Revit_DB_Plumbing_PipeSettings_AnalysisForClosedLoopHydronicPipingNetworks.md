---
kind: property
id: P:Autodesk.Revit.DB.Plumbing.PipeSettings.AnalysisForClosedLoopHydronicPipingNetworks
source: html/c8df4a55-893f-aeed-d388-51c923ff0c07.htm
---
# Autodesk.Revit.DB.Plumbing.PipeSettings.AnalysisForClosedLoopHydronicPipingNetworks Property

Indicates whether to enable analysis for closed loop hydronic piping networks.

## Syntax (C#)
```csharp
public bool AnalysisForClosedLoopHydronicPipingNetworks { get; set; }
```

## Remarks
For closed loop hydronic piping networks, Revit can analyze flow and pressure values for supply and return loops. In the model, select a pump to see the results of the analysis in the Properties palette. A closed loop hydronic piping network must contain: A single pump/circulatorA single source, such as a boilerMultiple piping segmentsMultiple terminals, such as radiators. A network may contain a direct return loop or a reverse return loop.

