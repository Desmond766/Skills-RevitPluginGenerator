---
kind: method
id: M:Autodesk.Revit.DB.Analysis.MEPAnalyticalModelData.GetSegmentById(System.Int32)
source: html/d251400b-5c09-ff21-6340-df144707123e.htm
---
# Autodesk.Revit.DB.Analysis.MEPAnalyticalModelData.GetSegmentById Method

Gets the analytical segment with the specified id.

## Syntax (C#)
```csharp
public MEPAnalyticalSegment GetSegmentById(
	int segmentId
)
```

## Parameters
- **segmentId** (`System.Int32`) - The segment id to be retrieved. This id is not 0 based.

## Returns
The returned analytical segment.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input must be a valid segment id.

