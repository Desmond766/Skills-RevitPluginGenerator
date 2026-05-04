---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.CanSuppressFirstOrLastBar(Autodesk.Revit.DB.View,System.Int32)
zh: 钢筋、配筋
source: html/4ed20a6e-a048-e483-3eba-5de536f6cd09.htm
---
# Autodesk.Revit.DB.Structure.Rebar.CanSuppressFirstOrLastBar Method

**中文**: 钢筋、配筋

Checks if the first or last bar in rebar set can be hidden in the given view.

## Syntax (C#)
```csharp
public bool CanSuppressFirstOrLastBar(
	View dBView,
	int end
)
```

## Parameters
- **dBView** (`Autodesk.Revit.DB.View`) - The view in which presentation mode will be applied.
- **end** (`System.Int32`) - 0 for the first bar in rebar set, 1 for the last bar.

## Returns
True the first or last bar in rebar set can be hidden for this view, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

