---
kind: property
id: P:Autodesk.Revit.DB.CurtainGridLine.AllSegmentCurves
source: html/122fa101-38a5-3f23-6c86-855f942df7e0.htm
---
# Autodesk.Revit.DB.CurtainGridLine.AllSegmentCurves Property

Retrieve the curves of all segments.

## Syntax (C#)
```csharp
public CurveArray AllSegmentCurves { get; }
```

## Remarks
User can get these curves and then call the method AddSegment() or RemoveSegment() to add/remove specified segments. 
 If the specified segment is already added/removed, nothing will happen.

