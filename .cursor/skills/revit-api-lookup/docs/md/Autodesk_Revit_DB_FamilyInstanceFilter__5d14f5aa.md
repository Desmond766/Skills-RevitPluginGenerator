---
kind: type
id: T:Autodesk.Revit.DB.FamilyInstanceFilter
source: html/ec0bdad7-e213-f22a-94ef-bc0fd96ac641.htm
---
# Autodesk.Revit.DB.FamilyInstanceFilter

A filter used to find elements that are family instances of the given family symbol.

## Syntax (C#)
```csharp
public class FamilyInstanceFilter : ElementSlowFilter
```

## Remarks
This filter is a slow filter, but it uses a quick filter to eliminate non-candidate elements
 before the elements are obtained and expanded. Therefore this filter does not have to be
 paired with another quick filter to minimize the number of Elements that are expanded.

