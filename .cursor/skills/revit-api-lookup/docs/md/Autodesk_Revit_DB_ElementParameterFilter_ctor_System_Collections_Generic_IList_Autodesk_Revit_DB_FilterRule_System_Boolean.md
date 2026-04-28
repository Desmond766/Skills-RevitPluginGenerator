---
kind: method
id: M:Autodesk.Revit.DB.ElementParameterFilter.#ctor(System.Collections.Generic.IList{Autodesk.Revit.DB.FilterRule},System.Boolean)
source: html/55dd89ad-62fd-6295-512c-7552b9a52312.htm
---
# Autodesk.Revit.DB.ElementParameterFilter.#ctor Method

Constructs a new instance of an ElementParameterFilter, with the option to match all elements not passing the given filter rules.

## Syntax (C#)
```csharp
public ElementParameterFilter(
	IList<FilterRule> filterRules,
	bool inverted
)
```

## Parameters
- **filterRules** (`System.Collections.Generic.IList < FilterRule >`) - The rules applied to test if the element passes this filter.
- **inverted** (`System.Boolean`) - True if the filter should match all elements which do not pass the filter rules.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The filterRules array is empty or invalid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

