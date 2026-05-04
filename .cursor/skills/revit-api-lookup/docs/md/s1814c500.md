---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarInSystem.IsBarHidden(Autodesk.Revit.DB.View,System.Int32)
source: html/8fa04d15-3891-4fe1-fa79-390a927d0d87.htm
---
# Autodesk.Revit.DB.Structure.RebarInSystem.IsBarHidden Method

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

