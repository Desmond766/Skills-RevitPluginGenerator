---
kind: property
id: P:Autodesk.Revit.DB.Family.FamilyCategoryId
zh: 族
source: html/c1e0b7fa-8ea0-b6f6-a300-4c3e231bdb95.htm
---
# Autodesk.Revit.DB.Family.FamilyCategoryId Property

**中文**: 族

The id of the category or sub category in which the elements that this family could generate reside.

## Syntax (C#)
```csharp
public ElementId FamilyCategoryId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The input category id cannot be assigned as the new category for this family.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The family is not an owner family for its own editable document.

