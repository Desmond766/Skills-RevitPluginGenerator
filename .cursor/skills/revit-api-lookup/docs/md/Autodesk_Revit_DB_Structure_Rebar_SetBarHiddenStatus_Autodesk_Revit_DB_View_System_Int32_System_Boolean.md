---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.SetBarHiddenStatus(Autodesk.Revit.DB.View,System.Int32,System.Boolean)
zh: 钢筋、配筋
source: html/9f58c248-58b9-47b9-4367-ead7f53695d6.htm
---
# Autodesk.Revit.DB.Structure.Rebar.SetBarHiddenStatus Method

**中文**: 钢筋、配筋

Sets the bar in this rebar set to be hidden or unhidden in the given view.

## Syntax (C#)
```csharp
public void SetBarHiddenStatus(
	View view,
	int barIndex,
	bool hide
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view.
- **barIndex** (`System.Int32`) - The index of the bar from this set.
- **hide** (`System.Boolean`) - True to hide this bar in the view, false to unhide the bar.

## Remarks
Individual bars of a rebar set can be hidden in a view only
 if the presentation mode is RebarPresentationMode.Select.
 If that is not the presentation mode assigned for this set in the view,
 this method will also change it.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This rebar cannot have a presentation mode applied for view, as the view is not valid for rebar presentation,
 or the orientation of the view matches the normal direction of the rebar element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - barIndex is not in the range [ 0, NumberOfBarPositions-1 ].
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This rebar element represents a single bar (the layout rule is Single).

