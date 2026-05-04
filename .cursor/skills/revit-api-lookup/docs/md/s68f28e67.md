---
kind: type
id: T:Autodesk.Revit.DB.AreaTagFilter
source: html/23cb7fbc-e93c-e3ea-54ca-e17a82d4116c.htm
---
# Autodesk.Revit.DB.AreaTagFilter

A filter used to match area tags.

## Syntax (C#)
```csharp
public class AreaTagFilter : ElementSlowFilter
```

## Remarks
This filter is a slow filter, but it uses a quick filter to eliminate non-candidate elements
 before the elements are obtained and expanded. Therefore this filter does not have to be
 paired with another quick filter to minimize the number of Elements that are expanded.

