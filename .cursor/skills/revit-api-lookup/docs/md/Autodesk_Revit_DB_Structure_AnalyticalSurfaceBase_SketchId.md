---
kind: property
id: P:Autodesk.Revit.DB.Structure.AnalyticalSurfaceBase.SketchId
source: html/41796d62-c246-f1db-dabf-f74f8cb209c7.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalSurfaceBase.SketchId Property

Sketch associated to this Revit element.

## Syntax (C#)
```csharp
public ElementId SketchId { get; }
```

## Remarks
Analytical Element may not have a valid sketch.
 To edit the sketch profile you can use SetOuterContour(CurveLoop) or [!:Autodesk::Revit::DB::SketchEditScope] .

