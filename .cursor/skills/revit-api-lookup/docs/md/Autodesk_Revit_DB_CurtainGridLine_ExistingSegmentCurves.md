---
kind: property
id: P:Autodesk.Revit.DB.CurtainGridLine.ExistingSegmentCurves
source: html/8595a252-e9fd-5537-2a78-2517dd950d28.htm
---
# Autodesk.Revit.DB.CurtainGridLine.ExistingSegmentCurves Property

Retrieve all the existing segment curves of the grid line.

## Syntax (C#)
```csharp
public CurveArray ExistingSegmentCurves { get; }
```

## Remarks
User can get these curves and call RemoveSegment() to remove the segments to the gridline or call AddMullions() to add mullions to these segments.

