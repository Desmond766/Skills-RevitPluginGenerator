---
kind: method
id: M:Autodesk.Revit.DB.Group.HideAttachedDetailGroups(Autodesk.Revit.DB.View,Autodesk.Revit.DB.ElementId)
source: html/660bd48f-dd60-562c-1935-8fcbd258669a.htm
---
# Autodesk.Revit.DB.Group.HideAttachedDetailGroups Method

Hides the element group's attached detail groups of the input group type that
 are compatible with the input view.

## Syntax (C#)
```csharp
public void HideAttachedDetailGroups(
	View view,
	ElementId detailGroupTypeId
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view that the attached detail groups must be compatible with.
- **detailGroupTypeId** (`Autodesk.Revit.DB.ElementId`) - Only attached detail groups of this type will be hidden.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The attached detail group detailGroupTypeId does not match the input view's orientation.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The input group is not a model group and can therefore not have attached detail groups.

