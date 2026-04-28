---
kind: method
id: M:Autodesk.Revit.DB.ElementLogicalFilter.SetFilters(System.Collections.Generic.IList{Autodesk.Revit.DB.ElementFilter})
source: html/8cab13fd-eb77-5f50-0d9c-e5ceda55d681.htm
---
# Autodesk.Revit.DB.ElementLogicalFilter.SetFilters Method

Replaces current filters in the logical filter with any number of input filters.

## Syntax (C#)
```csharp
public void SetFilters(
	IList<ElementFilter> filters
)
```

## Parameters
- **filters** (`System.Collections.Generic.IList < ElementFilter >`) - A collection of input filters.

## Remarks
The input filters will be copied.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The filter collection is empty, or contains invalid inputs.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

