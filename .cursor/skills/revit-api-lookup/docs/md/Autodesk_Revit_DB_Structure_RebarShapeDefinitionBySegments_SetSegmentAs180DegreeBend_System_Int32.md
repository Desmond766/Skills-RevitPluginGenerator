---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.SetSegmentAs180DegreeBend(System.Int32)
source: html/9f0878f6-602a-c3d1-fa1b-4452f62b8ced.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.SetSegmentAs180DegreeBend Method

Indicates that a segment is a "virtual" segment introduced to describe a 180-degree bend. The radius of the bend will be taken from the Bar Type.

## Syntax (C#)
```csharp
public void SetSegmentAs180DegreeBend(
	int iSegment
)
```

## Parameters
- **iSegment** (`System.Int32`) - Index of the segment (0 to NumberOfSegments - 1).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - iSegment is not between 0 and NumberOfSegments.

