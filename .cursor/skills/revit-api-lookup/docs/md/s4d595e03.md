---
kind: type
id: T:Autodesk.Revit.DB.ElementLevelFilter
source: html/844e4928-e11a-563f-b1e4-d4d16b8bd76b.htm
---
# Autodesk.Revit.DB.ElementLevelFilter

A filter used to match elements by their associated level.

## Syntax (C#)
```csharp
public class ElementLevelFilter : ElementSlowFilter
```

## Remarks
This filter is a slow filter.
 Slow filters require that the Element be obtained and expanded in memory first.
 Thus it is preferable to couple this filter with at least one ElementQuickFilter,
 which should minimize the number of Elements that are expanded.

