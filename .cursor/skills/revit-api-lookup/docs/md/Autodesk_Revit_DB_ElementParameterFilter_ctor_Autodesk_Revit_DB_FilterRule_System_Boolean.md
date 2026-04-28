---
kind: method
id: M:Autodesk.Revit.DB.ElementParameterFilter.#ctor(Autodesk.Revit.DB.FilterRule,System.Boolean)
source: html/49a99572-3d2d-a0dc-920b-205b923f32ec.htm
---
# Autodesk.Revit.DB.ElementParameterFilter.#ctor Method

Constructs a new instance of an ElementParameterFilter, with the option to match all elements not passing a given filter rule.

## Syntax (C#)
```csharp
public ElementParameterFilter(
	FilterRule filterRule,
	bool inverted
)
```

## Parameters
- **filterRule** (`Autodesk.Revit.DB.FilterRule`) - The rule applied to test if the element passes this filter.
- **inverted** (`System.Boolean`) - True if the filter should match all elements which do not pass the filter rule.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

