---
kind: type
id: T:Autodesk.Revit.DB.Structure.StructuralMaterialTypeFilter
source: html/8f1f6134-11dd-3c10-a4df-d11f30ee9ae8.htm
---
# Autodesk.Revit.DB.Structure.StructuralMaterialTypeFilter

A filter used to match family instances that have the given structural material type.

## Syntax (C#)
```csharp
public class StructuralMaterialTypeFilter : ElementSlowFilter
```

## Remarks
This filter is a slow filter, but it uses a quick filter to eliminate non-candidate elements
 before the elements are obtained and expanded. Therefore this filter does not have to be
 paired with another quick filter to minimize the number of Elements that are expanded.

