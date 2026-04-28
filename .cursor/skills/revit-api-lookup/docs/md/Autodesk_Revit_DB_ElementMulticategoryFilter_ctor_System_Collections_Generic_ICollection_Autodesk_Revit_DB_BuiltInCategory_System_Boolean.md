---
kind: method
id: M:Autodesk.Revit.DB.ElementMulticategoryFilter.#ctor(System.Collections.Generic.ICollection{Autodesk.Revit.DB.BuiltInCategory},System.Boolean)
source: html/775f6e25-3c2c-5d07-1cf6-94980f020792.htm
---
# Autodesk.Revit.DB.ElementMulticategoryFilter.#ctor Method

Constructs a new instance of a filter to match elements by built-in category, with the option to match all elements which are not of the given category.

## Syntax (C#)
```csharp
public ElementMulticategoryFilter(
	ICollection<BuiltInCategory> categories,
	bool inverted
)
```

## Parameters
- **categories** (`System.Collections.Generic.ICollection < BuiltInCategory >`) - The built-in categories to match.
- **inverted** (`System.Boolean`) - True if the filter should match all elements which are not of the given built-in categories.

