---
kind: method
id: M:Autodesk.Revit.DB.Analysis.MEPAnalyticalModelData.GetSegmentData(System.Int32)
source: html/9f0dcd5d-569a-4e50-3c9a-39491227840d.htm
---
# Autodesk.Revit.DB.Analysis.MEPAnalyticalModelData.GetSegmentData Method

Gets the analysis data on the specified segment.

## Syntax (C#)
```csharp
public MEPNetworkSegmentData GetSegmentData(
	int segmentId
)
```

## Parameters
- **segmentId** (`System.Int32`) - The segment id to be retrieved.

## Returns
The calculated data of this segment. Be aware that the segment data may be invalid if the calculation failed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input must be a valid segment id.

