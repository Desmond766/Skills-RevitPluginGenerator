---
kind: method
id: M:Autodesk.Revit.DB.Group.ShowAllAttachedDetailGroups(Autodesk.Revit.DB.View)
source: html/e6c7cae5-a513-e212-8139-20abf9f40ba1.htm
---
# Autodesk.Revit.DB.Group.ShowAllAttachedDetailGroups Method

Shows all the available attached detail groups for this element group type that
 are compatible with the input view type.

## Syntax (C#)
```csharp
public void ShowAllAttachedDetailGroups(
	View view
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view that the attached detail groups must be compatible with.

## Remarks
Currently, perpendicular elevation views (for example, North and East views) are considered
 compatible when deciding whether or not to allow a detail group to be displayed in a view.
 The show operation may generate an error (FailureMessage) based on id if the orientation of the
 annotations do not match the orientation of the target view (for example, the failure definition
 DimensionPerpendicularToView). To prevent displaying detail groups in the wrong view, you can
 check the OwnerViewId of a detail group to make sure it matches the view in which you are trying
 to display it.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The input group is not a model group and can therefore not have attached detail groups.
 -or-
 This exception is thrown if this group's attached detail groups cannot be found in the current document.

