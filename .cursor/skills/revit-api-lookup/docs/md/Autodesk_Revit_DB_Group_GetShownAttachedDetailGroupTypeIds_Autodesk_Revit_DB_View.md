---
kind: method
id: M:Autodesk.Revit.DB.Group.GetShownAttachedDetailGroupTypeIds(Autodesk.Revit.DB.View)
source: html/39290399-a9b1-52ed-cfcf-33c24b9b675c.htm
---
# Autodesk.Revit.DB.Group.GetShownAttachedDetailGroupTypeIds Method

Returns the attached detail groups which have displayed instances for
 this group type in the input view.

## Syntax (C#)
```csharp
public ISet<ElementId> GetShownAttachedDetailGroupTypeIds(
	View view
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view in which the attached detail groups are displayed.

## Returns
The collection of attached detail group Ids that match this group's type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The input group is not a model group and can therefore not have attached detail groups.

