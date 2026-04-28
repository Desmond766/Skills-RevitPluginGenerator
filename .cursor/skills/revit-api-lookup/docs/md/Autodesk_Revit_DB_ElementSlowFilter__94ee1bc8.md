---
kind: type
id: T:Autodesk.Revit.DB.ElementSlowFilter
source: html/e06b1e14-dd8d-8137-74ac-8ac4929eee85.htm
---
# Autodesk.Revit.DB.ElementSlowFilter

A base class for a type of filter that operates on expanded elements.

## Syntax (C#)
```csharp
public class ElementSlowFilter : ElementFilter
```

## Remarks
Slow filters require that the Element be obtained and expanded in memory first.
 Thus it is preferable to couple slow filters with at least one ElementQuickFilter,
 which should minimize the number of Elements that are expanded in order to evaluate
 against the criteria set by this filter.

