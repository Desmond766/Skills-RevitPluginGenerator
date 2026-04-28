---
kind: property
id: P:Autodesk.Revit.DB.CurtainGridLine.SkippedSegmentCurves
source: html/8456b83c-bbb2-c22c-5bb1-23521721b545.htm
---
# Autodesk.Revit.DB.CurtainGridLine.SkippedSegmentCurves Property

Retrieve all the removed segment curves of the grid line.

## Syntax (C#)
```csharp
public CurveArray SkippedSegmentCurves { get; }
```

## Remarks
User can get these curves and then call the method AddSegment() to add the segments to the grid line.

