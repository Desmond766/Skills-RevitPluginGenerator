---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.UngroupHeaders(System.Int32,System.Int32,System.Int32,System.Int32)
zh: 明细表
source: html/682bd641-f652-96b0-9644-210282a56047.htm
---
# Autodesk.Revit.DB.ViewSchedule.UngroupHeaders Method

**中文**: 明细表

Ungroups selected headers of schedule.

## Syntax (C#)
```csharp
public void UngroupHeaders(
	int top,
	int left,
	int bottom,
	int right
)
```

## Parameters
- **top** (`System.Int32`) - The index of the top row of the selected headers.
- **left** (`System.Int32`) - The index of the left column of the selected headers.
- **bottom** (`System.Int32`) - The index of the bottom row of the selected headers.
- **right** (`System.Int32`) - The index of the right column of the selected headers.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Headers could not be ungrouped.

