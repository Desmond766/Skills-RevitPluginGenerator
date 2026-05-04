---
kind: method
id: M:Autodesk.Revit.DB.ElementMulticategoryFilter.#ctor(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},System.Boolean)
source: html/8db0f1e1-f7f2-7b73-ed52-4eeaba0201d5.htm
---
# Autodesk.Revit.DB.ElementMulticategoryFilter.#ctor Method

Constructs a new instance of a filter to find elements whose category matches any of a given set of categories, with the option to instead match elements which are not of the given categories.

## Syntax (C#)
```csharp
public ElementMulticategoryFilter(
	ICollection<ElementId> categoryIds,
	bool inverted
)
```

## Parameters
- **categoryIds** (`System.Collections.Generic.ICollection < ElementId >`) - The category ids to match.
- **inverted** (`System.Boolean`) - True if the filter should match all elements which are not of the given categories.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more categories was not valid for filtering.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

