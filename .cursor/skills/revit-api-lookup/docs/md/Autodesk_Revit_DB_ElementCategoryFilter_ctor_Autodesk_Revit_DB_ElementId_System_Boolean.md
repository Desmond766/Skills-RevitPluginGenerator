---
kind: method
id: M:Autodesk.Revit.DB.ElementCategoryFilter.#ctor(Autodesk.Revit.DB.ElementId,System.Boolean)
source: html/3590e7e3-3e05-2d1a-f2af-8033eeb8996b.htm
---
# Autodesk.Revit.DB.ElementCategoryFilter.#ctor Method

Constructs a new instance of a filter to match elements by category, with the option to match all elements which are of the given category.

## Syntax (C#)
```csharp
public ElementCategoryFilter(
	ElementId categoryId,
	bool inverted
)
```

## Parameters
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The category id to match.
- **inverted** (`System.Boolean`) - True if the filter should match all elements which are not of the given category.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The category was not valid for filtering.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

