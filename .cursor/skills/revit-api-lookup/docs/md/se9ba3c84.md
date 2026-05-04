---
kind: method
id: M:Autodesk.Revit.DB.CurtainGridLine.RemoveSegment(Autodesk.Revit.DB.Curve)
source: html/024f4880-1bfd-0819-a1b3-8cd11113cfad.htm
---
# Autodesk.Revit.DB.CurtainGridLine.RemoveSegment Method

Remove the segment specified by the input curve.

## Syntax (C#)
```csharp
public void RemoveSegment(
	Curve curve
)
```

## Parameters
- **curve** (`Autodesk.Revit.DB.Curve`) - The curve used to locate the segment to be removed.

## Remarks
When a segment is removed, the neighboring two panels will be merged into one panel. This function will invoke regeneration.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Segment may not have been found in location indicated by curve.

