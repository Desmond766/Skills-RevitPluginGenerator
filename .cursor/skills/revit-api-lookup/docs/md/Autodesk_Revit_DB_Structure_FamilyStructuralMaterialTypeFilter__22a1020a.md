---
kind: type
id: T:Autodesk.Revit.DB.Structure.FamilyStructuralMaterialTypeFilter
source: html/964fd00d-21ec-b212-07b5-159c85bbc021.htm
---
# Autodesk.Revit.DB.Structure.FamilyStructuralMaterialTypeFilter

A filter used to match families that have the given structural material type.

## Syntax (C#)
```csharp
public class FamilyStructuralMaterialTypeFilter : ElementSlowFilter
```

## Remarks
This filter is a slow filter, but it uses a quick filter to eliminate non-candidate elements
 before the elements are obtained and expanded. Therefore this filter does not have to be
 paired with another quick filter to minimize the number of Elements that are expanded.

