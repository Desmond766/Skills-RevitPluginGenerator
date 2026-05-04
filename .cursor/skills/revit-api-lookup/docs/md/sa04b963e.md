---
kind: type
id: T:Autodesk.Revit.DB.Mechanical.SpaceTagFilter
source: html/b552fa72-06b5-fee9-507e-2e97afe8241e.htm
---
# Autodesk.Revit.DB.Mechanical.SpaceTagFilter

A filter used to match space tags.

## Syntax (C#)
```csharp
public class SpaceTagFilter : ElementSlowFilter
```

## Remarks
This filter is a slow filter, but it uses a quick filter to eliminate non-candidate elements
 before the elements are obtained and expanded. Therefore this filter does not have to be
 paired with another quick filter to minimize the number of Elements that are expanded.

