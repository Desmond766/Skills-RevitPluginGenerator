---
kind: method
id: M:Autodesk.Revit.DB.ElementParameterFilter.#ctor(System.Collections.Generic.IList{Autodesk.Revit.DB.FilterRule})
source: html/6d7271d3-7717-5a01-ebb1-8c3723b6ebb6.htm
---
# Autodesk.Revit.DB.ElementParameterFilter.#ctor Method

Constructs a new instance of an ElementParameterFilter from a set of rules.

## Syntax (C#)
```csharp
public ElementParameterFilter(
	IList<FilterRule> filterRules
)
```

## Parameters
- **filterRules** (`System.Collections.Generic.IList < FilterRule >`) - The rules applied to test if the element passes this filter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The filterRules array is empty or invalid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

