---
kind: method
id: M:Autodesk.Revit.DB.Group.HideAllAttachedDetailGroups(Autodesk.Revit.DB.View)
source: html/df7937f2-c48b-8549-a7e2-f2fd1cbafa7b.htm
---
# Autodesk.Revit.DB.Group.HideAllAttachedDetailGroups Method

Hides all the available attached detail groups for this element group type that
 are compatible with the input view type.

## Syntax (C#)
```csharp
public void HideAllAttachedDetailGroups(
	View view
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view that the attached detail groups must be compatible with.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The input group is not a model group and can therefore not have attached detail groups.

