---
kind: type
id: T:Autodesk.Revit.DB.AreaFilter
source: html/a13bb51e-5370-99ed-d212-bdd60297393d.htm
---
# Autodesk.Revit.DB.AreaFilter

A filter used to match areas.

## Syntax (C#)
```csharp
public class AreaFilter : ElementSlowFilter
```

## Remarks
This filter is a slow filter, but it uses a quick filter to eliminate non-candidate elements
 before the elements are obtained and expanded. Therefore this filter does not have to be
 paired with another quick filter to minimize the number of Elements that are expanded.

