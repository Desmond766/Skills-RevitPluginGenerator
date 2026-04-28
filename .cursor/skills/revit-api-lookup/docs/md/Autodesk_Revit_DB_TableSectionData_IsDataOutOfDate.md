---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.IsDataOutOfDate
source: html/be0dd26c-d514-878b-6f15-2276ec8c99d3.htm
---
# Autodesk.Revit.DB.TableSectionData.IsDataOutOfDate Method

Indicates whether the data in this section is out of date.

## Syntax (C#)
```csharp
public bool IsDataOutOfDate()
```

## Returns
True if the data in this section is out of date, false otherwise.

## Remarks
To improve performance, some TableViews may contain TableSections that are only updated on demand. For example,
 the body section of a schedule is not updated when the ViewSchedule is closed. In this case, you need to call
 RefreshData to avoid getting the stale data.

