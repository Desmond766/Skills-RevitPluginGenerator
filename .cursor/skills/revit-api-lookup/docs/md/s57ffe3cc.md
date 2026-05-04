---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.CanGroupHeaders(System.Int32,System.Int32,System.Int32,System.Int32)
zh: 明细表
source: html/509911b4-ea7b-535d-f5f6-3b377c292e4c.htm
---
# Autodesk.Revit.DB.ViewSchedule.CanGroupHeaders Method

**中文**: 明细表

Indicates if selected headers can be grouped for this schedule.

## Syntax (C#)
```csharp
public bool CanGroupHeaders(
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

