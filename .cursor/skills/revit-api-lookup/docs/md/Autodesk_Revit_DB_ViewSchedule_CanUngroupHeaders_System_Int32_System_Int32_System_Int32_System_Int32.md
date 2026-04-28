---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.CanUngroupHeaders(System.Int32,System.Int32,System.Int32,System.Int32)
zh: 明细表
source: html/2c5cbf50-8d29-a5d2-103d-06621e08da0b.htm
---
# Autodesk.Revit.DB.ViewSchedule.CanUngroupHeaders Method

**中文**: 明细表

Indicates if selected headers can be ungrouped.

## Syntax (C#)
```csharp
public bool CanUngroupHeaders(
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

## Returns
True if the selected headers can be grouped, false otherwise.

