---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.MergeSegments(System.Int32,System.Int32)
zh: 明细表
source: html/2a393e25-4c5f-5bd1-de98-58b2774de3cc.htm
---
# Autodesk.Revit.DB.ViewSchedule.MergeSegments Method

**中文**: 明细表

Merges two adjacent segments into one.

## Syntax (C#)
```csharp
public void MergeSegments(
	int movedSegmentIndex,
	int targetSegmentIndex
)
```

## Parameters
- **movedSegmentIndex** (`System.Int32`) - The index of the moved segment.
- **targetSegmentIndex** (`System.Int32`) - The index of the target segment.

## Remarks
Only adjacent segments can be merged. The moved segment will be deleted with all its instances
 on sheet and all the data will be merged into the target segment with height expanded.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Only two adjacent segments can be merged.
 -or-
 The segment index should start from 0 and be less than the total segment count.

