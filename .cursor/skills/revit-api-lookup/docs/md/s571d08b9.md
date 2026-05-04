---
kind: type
id: T:Autodesk.Revit.DB.ElementPhaseStatusFilter
source: html/7767020a-2564-2c46-689d-59c2abe6e777.htm
---
# Autodesk.Revit.DB.ElementPhaseStatusFilter

A filter used to match elements that have a given phase status on a given phase.

## Syntax (C#)
```csharp
public class ElementPhaseStatusFilter : ElementSlowFilter
```

## Remarks
This filter is a slow filter.
 Slow filters require that the Element be obtained and expanded in memory first.
 Thus it is preferable to couple this filter with at least one ElementQuickFilter,
 which should minimize the number of Elements that are expanded.

