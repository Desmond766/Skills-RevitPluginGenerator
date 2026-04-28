---
kind: type
id: T:Autodesk.Revit.DB.ElementParameterFilter
source: html/b0b40351-690c-eb5d-30c2-d4447a42fda1.htm
---
# Autodesk.Revit.DB.ElementParameterFilter

A filter used to match elements by one or more parameter filter rules.

## Syntax (C#)
```csharp
public class ElementParameterFilter : ElementSlowFilter
```

## Remarks
This filter is a slow filter.
 Slow filters require that the Element be obtained and expanded in memory first.
 Thus it is preferable to couple this filter with at least one ElementQuickFilter,
 which should minimize the number of Elements that are expanded.

