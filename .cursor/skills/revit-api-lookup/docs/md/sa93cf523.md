---
kind: method
id: M:Autodesk.Revit.DB.ElementCategoryFilter.#ctor(Autodesk.Revit.DB.BuiltInCategory,System.Boolean)
source: html/abd2686e-aa6b-c8b5-78d0-a7965451d287.htm
---
# Autodesk.Revit.DB.ElementCategoryFilter.#ctor Method

Constructs a new instance of a filter to match elements by category, with the option to match all elements which are not of the given category.

## Syntax (C#)
```csharp
public ElementCategoryFilter(
	BuiltInCategory category,
	bool inverted
)
```

## Parameters
- **category** (`Autodesk.Revit.DB.BuiltInCategory`) - The category to match.
- **inverted** (`System.Boolean`) - True if the filter should match all elements which are not of the given category.

