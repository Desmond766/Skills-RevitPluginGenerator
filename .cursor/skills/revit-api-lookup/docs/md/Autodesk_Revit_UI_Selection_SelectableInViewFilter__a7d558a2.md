---
kind: type
id: T:Autodesk.Revit.UI.Selection.SelectableInViewFilter
source: html/4def5498-f47f-870c-ea25-0408b6603dac.htm
---
# Autodesk.Revit.UI.Selection.SelectableInViewFilter

A filter that passes elements that are selectable in the given view.

## Syntax (C#)
```csharp
public class SelectableInViewFilter : ElementSlowFilter
```

## Remarks
This filter is a slow filter. Slow filters require that the Element be obtained and expanded in memory first.
 Thus it is preferable to couple this filter with at least one ElementQuickFilter,
 which should minimize the number of Elements that are expanded.
 This filter is designed to operate on a list of elements visible in the given view.
 This can be obtained from a FilteredElementCollector constructed with the view id.
 This filter may not correctly restrict elements which are not a part of the visible elements of the view.

