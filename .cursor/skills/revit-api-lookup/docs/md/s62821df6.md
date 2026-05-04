---
kind: type
id: T:Autodesk.Revit.DB.VisibleInViewFilter
source: html/2425b0fb-7b28-1609-e45e-f1e196885248.htm
---
# Autodesk.Revit.DB.VisibleInViewFilter

A quick filter that passes elements that are most likely visible in the given view.

## Syntax (C#)
```csharp
public class VisibleInViewFilter : ElementQuickFilter
```

## Remarks
This filter is a quick filter.
 Quick filters operate only on the ElementRecord, a low-memory class which has
 a limited interface to read element properties. Elements which are rejected
 by a quick filter will not be expanded in memory.
 In some situations (for example, when the element geometry is not yet calculated for the input view)
 this filter may return true even though the element may not actually be visible when geometry is calculated.

