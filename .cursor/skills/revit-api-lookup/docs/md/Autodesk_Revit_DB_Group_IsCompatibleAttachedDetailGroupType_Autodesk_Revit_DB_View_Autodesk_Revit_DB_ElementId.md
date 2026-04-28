---
kind: method
id: M:Autodesk.Revit.DB.Group.IsCompatibleAttachedDetailGroupType(Autodesk.Revit.DB.View,Autodesk.Revit.DB.ElementId)
source: html/60562c31-ef34-4cbd-77bc-3fe89a8d2f38.htm
---
# Autodesk.Revit.DB.Group.IsCompatibleAttachedDetailGroupType Method

Checks if the orientation of the input attached detail group matches the input view's orientation.

## Syntax (C#)
```csharp
public bool IsCompatibleAttachedDetailGroupType(
	View view,
	ElementId detailGroupTypeId
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view that the input attached detail group must be compatible with.
- **detailGroupTypeId** (`Autodesk.Revit.DB.ElementId`) - The attached detail group that will be checked for compatibility with the input view.

## Returns
Returns true if the input attached detail group is compatible with the input view and false otherwise.

## Remarks
Currently, detail groups in perpendicular elevation views (for example, North and East views)
 are considered compatible. When showing these detail groups, an error (FailureMessage) based on
 id can be generated if the orientation of the annotations do not match the orientation of the
 target view (for example, the failure definition DimensionPerpendicularToView). To prevent
 displaying detail groups in the wrong view, you can check the OwnerViewId of a detail group
 to make sure it matches the view in which you are trying to display it.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The input group is not a model group and can therefore not have attached detail groups.

