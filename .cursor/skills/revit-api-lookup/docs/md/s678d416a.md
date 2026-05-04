---
kind: type
id: T:Autodesk.Revit.DB.PrimaryDesignOptionMemberFilter
source: html/9d96ca9c-c89a-818c-44bb-63e5926b72fd.htm
---
# Autodesk.Revit.DB.PrimaryDesignOptionMemberFilter

A filter used to find elements contained in any primary design option of any design option set.

## Syntax (C#)
```csharp
public class PrimaryDesignOptionMemberFilter : ElementSlowFilter
```

## Remarks
This filter will only pass elements in a primary design option. It will not pass elements in the main model not associated
 to any design option.
 This filter is a slow filter.
 Slow filters require that the Element be obtained and expanded in memory first.
 Thus it is preferable to couple this filter with at least one ElementQuickFilter,
 which should minimize the number of Elements that are expanded.

