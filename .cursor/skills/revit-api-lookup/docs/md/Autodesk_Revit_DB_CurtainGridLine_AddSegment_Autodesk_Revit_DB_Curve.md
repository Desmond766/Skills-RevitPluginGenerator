---
kind: method
id: M:Autodesk.Revit.DB.CurtainGridLine.AddSegment(Autodesk.Revit.DB.Curve)
source: html/0e6a1adb-8953-4afb-9769-34f8142e50ee.htm
---
# Autodesk.Revit.DB.CurtainGridLine.AddSegment Method

Add a segment based on the specified segment curve of the gridline.

## Syntax (C#)
```csharp
public void AddSegment(
	Curve curve
)
```

## Parameters
- **curve** (`Autodesk.Revit.DB.Curve`) - The curve used to locate the segment to be removed. This function will invoke regeneration.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Segment may not have been found in location indicated by curve.

