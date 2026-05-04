---
kind: type
id: T:Autodesk.Revit.DB.Structure.StructuralInstanceUsageFilter
source: html/d75dfb58-cf2f-1d33-20f1-add1cedad770.htm
---
# Autodesk.Revit.DB.Structure.StructuralInstanceUsageFilter

A filter used to find elements that are structural family instances (typically columns, beams or braces) of the given structural usage.

## Syntax (C#)
```csharp
public class StructuralInstanceUsageFilter : ElementSlowFilter
```

## Remarks
This filter is a slow filter, but it uses a quick filter to eliminate non-candidate elements
 before the elements are obtained and expanded. Therefore this filter does not have to be
 paired with another quick filter to minimize the number of Elements that are expanded.

