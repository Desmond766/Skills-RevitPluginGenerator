---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.FindMatchingPredefinedPresentationMode(Autodesk.Revit.DB.View)
zh: 钢筋、配筋
source: html/b1cd999d-3630-47df-e357-4149651d9385.htm
---
# Autodesk.Revit.DB.Structure.Rebar.FindMatchingPredefinedPresentationMode Method

**中文**: 钢筋、配筋

Determines if there is a matching RebarPresentationMode for the current set of selected hidden and unhidden bars assigned to the given view.

## Syntax (C#)
```csharp
public RebarPresentationMode FindMatchingPredefinedPresentationMode(
	View dBView
)
```

## Parameters
- **dBView** (`Autodesk.Revit.DB.View`) - The view.

## Returns
The presentation mode that matches the current set of selected hidden and unhidden bars.
 If there is no better match, this returns RebarPresentationMode.Select.

## Remarks
If the presentation mode is not PresentationMode.Select for the view, this function returns the current mode.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

