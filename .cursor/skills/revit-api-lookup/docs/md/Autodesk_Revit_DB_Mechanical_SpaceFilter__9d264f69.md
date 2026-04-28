---
kind: type
id: T:Autodesk.Revit.DB.Mechanical.SpaceFilter
source: html/aefc66b3-bbf1-f66a-4901-953137e9c051.htm
---
# Autodesk.Revit.DB.Mechanical.SpaceFilter

A filter used to match spaces.

## Syntax (C#)
```csharp
public class SpaceFilter : ElementSlowFilter
```

## Remarks
This filter is a slow filter, but it uses a quick filter to eliminate non-candidate elements
 before the elements are obtained and expanded. Therefore this filter does not have to be
 paired with another quick filter to minimize the number of Elements that are expanded.

