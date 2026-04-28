---
kind: type
id: T:Autodesk.Revit.DB.Structure.RebarShapeVertex
source: html/ef7d9a62-94b7-dfde-3175-e3dd616d49f3.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeVertex

A bend between segments of a rebar shape definition.

## Syntax (C#)
```csharp
public class RebarShapeVertex : IDisposable
```

## Remarks
A RebarShapeVertex is part of a RebarShapeDefinitionBySegments object.
 There is one vertex between each pair of adjacent segments, plus one at
 each end of the overall shape. The end vertices currently are ignored
 by the shape definition, even if they have constraints.
A bend may have the default radius of the bar type referenced by the Rebar element,
 or it may have a radius defined by a parameter.

