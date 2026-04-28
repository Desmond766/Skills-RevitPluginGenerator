---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.GetSegment(System.Int32)
source: html/7c31cede-dc2f-c8fd-5cd7-adbd610fef14.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.GetSegment Method

Return a reference to one of the segments in the definition.

## Syntax (C#)
```csharp
public RebarShapeSegment GetSegment(
	int segmentIndex
)
```

## Parameters
- **segmentIndex** (`System.Int32`) - Index of the segment (0 to NumberOfSegments - 1).

## Returns
The requested segment.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - segmentIndex is not between 0 and NumberOfSegments.

