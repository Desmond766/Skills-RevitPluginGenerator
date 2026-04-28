---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.SetSegmentVariableDirection(System.Int32)
source: html/acf072d6-2253-36df-13be-ccf49320cf0f.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.SetSegmentVariableDirection Method

Remove the fixed direction from a segment.

## Syntax (C#)
```csharp
public void SetSegmentVariableDirection(
	int iSegment
)
```

## Parameters
- **iSegment** (`System.Int32`) - Index of the segment (0 to NumberOfSegments - 1).

## Remarks
The segment's angle will be allowed to vary, with a range of 90 degrees. The segment must have at least two constraints.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - iSegment is not between 0 and NumberOfSegments.

