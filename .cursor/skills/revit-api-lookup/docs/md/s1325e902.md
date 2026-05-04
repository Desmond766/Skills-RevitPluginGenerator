---
kind: method
id: M:Autodesk.Revit.DB.Group.ShowAttachedDetailGroups(Autodesk.Revit.DB.View,Autodesk.Revit.DB.ElementId)
source: html/2e4d7640-92fa-fc3b-83a2-e492bc8b0269.htm
---
# Autodesk.Revit.DB.Group.ShowAttachedDetailGroups Method

Shows the element group's attached detail groups of the input group type that
 are compatible with the input view.

## Syntax (C#)
```csharp
public void ShowAttachedDetailGroups(
	View view,
	ElementId detailGroupTypeId
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view that the attached detail groups must be compatible with.
- **detailGroupTypeId** (`Autodesk.Revit.DB.ElementId`) - Only attached detail groups of this type will be shown.

## Remarks
Currently, perpendicular elevation views (for example, North and East views) are considered
 compatible when deciding whether or not to allow a detail group to be displayed in a view.
 The show operation may generate an error (FailureMessage) based on id if the orientation of the
 annotations do not match the orientation of the target view (for example, the failure definition
 DimensionPerpendicularToView). To prevent displaying detail groups in the wrong view, you can
 check the OwnerViewId of a detail group to make sure it matches the view in which you are trying
 to display it.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The attached detail group detailGroupTypeId does not match the input view's orientation.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The input group is not a model group and can therefore not have attached detail groups.
 -or-
 This exception is thrown if the input attached detail group cannot be found in the current document.

