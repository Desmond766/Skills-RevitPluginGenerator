---
kind: method
id: M:Autodesk.Revit.DB.FamilyInstance.GetFamilyPointPlacementReferences
zh: 族实例
source: html/59db15da-7e87-a85f-bacf-e8a636d17022.htm
---
# Autodesk.Revit.DB.FamilyInstance.GetFamilyPointPlacementReferences Method

**中文**: 族实例

Returns the Point Placement References for the Family Instance.

## Syntax (C#)
```csharp
public IList<FamilyPointPlacementReference> GetFamilyPointPlacementReferences()
```

## Remarks
If a family instance has point placement references then they are returned by this method,
otherwise an empty collection is returned. Examples of FamilyInstance objects that contain placement
references are Panels and Flexible Components.

