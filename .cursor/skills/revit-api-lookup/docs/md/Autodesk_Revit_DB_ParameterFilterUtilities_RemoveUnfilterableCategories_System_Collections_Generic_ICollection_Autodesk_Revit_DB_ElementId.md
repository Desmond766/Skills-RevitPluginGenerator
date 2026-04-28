---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterUtilities.RemoveUnfilterableCategories(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/21cd2cd7-3054-d114-1f32-efbbfd069ef0.htm
---
# Autodesk.Revit.DB.ParameterFilterUtilities.RemoveUnfilterableCategories Method

Removes from the given set the categories that are not filterable.

## Syntax (C#)
```csharp
public static ICollection<ElementId> RemoveUnfilterableCategories(
	ICollection<ElementId> categories
)
```

## Parameters
- **categories** (`System.Collections.Generic.ICollection < ElementId >`) - The set of categories to check.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

