---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetSegmentOrientation(System.Int32)
source: html/9f4b22d2-8bc1-4e07-9f5a-aebc92cb3e38.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetSegmentOrientation Method

Gets the orientation of a segment.

## Syntax (C#)
```csharp
public RectangularGridSegmentOrientation GetSegmentOrientation(
	int segmentId
)
```

## Parameters
- **segmentId** (`System.Int32`) - The id of a segment in this CompoundStructure.

## Returns
The orientation of the specified segment.

## Remarks
The boundaries of the regions of a vertically compound structure consist of vertical
 horizontal segments.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The segment id is invalid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is valid only for vertically compound structures.

