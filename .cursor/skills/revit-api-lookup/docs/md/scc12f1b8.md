---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.GroupHeaders(System.Int32,System.Int32,System.Int32,System.Int32,System.String)
zh: 明细表
source: html/62a4bc0e-5226-eaed-2881-0bc0a8f259d6.htm
---
# Autodesk.Revit.DB.ViewSchedule.GroupHeaders Method

**中文**: 明细表

Groups schedule header cells.

## Syntax (C#)
```csharp
public void GroupHeaders(
	int top,
	int left,
	int bottom,
	int right,
	string caption
)
```

## Parameters
- **top** (`System.Int32`) - The index of the top row of the selected headers.
- **left** (`System.Int32`) - The index of the left column of the selected headers.
- **bottom** (`System.Int32`) - The index of the bottom row of the selected headers.
- **right** (`System.Int32`) - The index of the right column of the selected headers.
- **caption** (`System.String`) - The header caption.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Headers could not be grouped.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

