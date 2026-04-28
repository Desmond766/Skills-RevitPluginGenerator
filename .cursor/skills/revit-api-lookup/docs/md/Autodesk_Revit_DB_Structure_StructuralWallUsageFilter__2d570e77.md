---
kind: type
id: T:Autodesk.Revit.DB.Structure.StructuralWallUsageFilter
source: html/43b4c666-5f81-bd42-dfb5-d1d86f517dee.htm
---
# Autodesk.Revit.DB.Structure.StructuralWallUsageFilter

A filter used to match walls that have the given structural wall usage.

## Syntax (C#)
```csharp
public class StructuralWallUsageFilter : ElementSlowFilter
```

## Remarks
This filter is a slow filter, but it uses a quick filter to eliminate non-candidate elements
 before the elements are obtained and expanded. Therefore this filter does not have to be
 paired with another quick filter to minimize the number of Elements that are expanded.

