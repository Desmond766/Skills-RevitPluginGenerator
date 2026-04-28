---
kind: method
id: M:Autodesk.Revit.DB.CurtainGridLine.AddMullions(Autodesk.Revit.DB.Curve,Autodesk.Revit.DB.MullionType,System.Boolean)
source: html/c6a78e90-5ce1-5bf3-cb82-f3de750e0255.htm
---
# Autodesk.Revit.DB.CurtainGridLine.AddMullions Method

Add mullions on the specified segments of a grid. If any segment already has a mullion, no change is made to that segment.

## Syntax (C#)
```csharp
public ElementSet AddMullions(
	Curve segment,
	MullionType mullionType,
	bool oneSegmentOnly
)
```

## Parameters
- **segment** (`Autodesk.Revit.DB.Curve`) - Curve of the segment.
- **mullionType** (`Autodesk.Revit.DB.MullionType`) - The type of the mullion to add.
- **oneSegmentOnly** (`System.Boolean`) - If true, add one mullion to the specified segment, otherwise add mullions to all the segments of the matching grid line.

## Returns
If operation succeeds, the created mullions will be returned.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Invalid curtain grid line or invalid mullion type argument.

