---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.IsBarHidden(Autodesk.Revit.DB.View,System.Int32)
zh: 钢筋、配筋
source: html/d066eb29-243b-bcc9-2468-c5df0f255a13.htm
---
# Autodesk.Revit.DB.Structure.Rebar.IsBarHidden Method

**中文**: 钢筋、配筋

Identifies if a given bar in this rebar set is hidden in this view.

## Syntax (C#)
```csharp
public bool IsBarHidden(
	View view,
	int barIndex
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view.
- **barIndex** (`System.Int32`) - The index of the bar from this rebar set.

## Returns
True if the bar is hidden in this view, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - barIndex is not in the range [ 0, NumberOfBarPositions-1 ].

