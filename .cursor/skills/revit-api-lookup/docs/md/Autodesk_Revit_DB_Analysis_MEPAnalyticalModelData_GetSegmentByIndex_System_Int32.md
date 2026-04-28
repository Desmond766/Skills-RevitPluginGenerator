---
kind: method
id: M:Autodesk.Revit.DB.Analysis.MEPAnalyticalModelData.GetSegmentByIndex(System.Int32)
source: html/459a0ee4-5aa7-5a7a-dc1d-405a9cb5dec8.htm
---
# Autodesk.Revit.DB.Analysis.MEPAnalyticalModelData.GetSegmentByIndex Method

Gets the analytical segment at the specified position.

## Syntax (C#)
```csharp
public MEPAnalyticalSegment GetSegmentByIndex(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The index where the segment is stored. This index is 0 based.

## Returns
The returned analytical segment.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The index must range from 0 to GetNumberOfSegments()-1.

