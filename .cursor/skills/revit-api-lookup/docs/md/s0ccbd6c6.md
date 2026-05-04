---
kind: method
id: M:Autodesk.Revit.DB.LogicalOrFilter.#ctor(System.Collections.Generic.IList{Autodesk.Revit.DB.ElementFilter})
source: html/c8085da4-8a13-f660-a316-19b53768ae22.htm
---
# Autodesk.Revit.DB.LogicalOrFilter.#ctor Method

Constructs a new instance of the logical filter with any number of input filters.

## Syntax (C#)
```csharp
public LogicalOrFilter(
	IList<ElementFilter> filters
)
```

## Parameters
- **filters** (`System.Collections.Generic.IList < ElementFilter >`) - A collection of input filters.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The filter collection is empty, or contains invalid inputs.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

