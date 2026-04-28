---
kind: method
id: M:Autodesk.Revit.DB.FilterCategoryRule.SetCategories(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/4e30b67e-56c0-8ba8-90a2-71cee5b004d2.htm
---
# Autodesk.Revit.DB.FilterCategoryRule.SetCategories Method

Sets the rule's categories.

## Syntax (C#)
```csharp
public bool SetCategories(
	ICollection<ElementId> categories
)
```

## Parameters
- **categories** (`System.Collections.Generic.ICollection < ElementId >`) - The categories.

## Returns
True if the set of categories was changed, false if no change was necessary.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One of the given categories is not filterable
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

