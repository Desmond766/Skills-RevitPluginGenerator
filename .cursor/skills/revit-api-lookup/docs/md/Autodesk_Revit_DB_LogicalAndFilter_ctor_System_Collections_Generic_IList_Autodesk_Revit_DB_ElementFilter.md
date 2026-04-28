---
kind: method
id: M:Autodesk.Revit.DB.LogicalAndFilter.#ctor(System.Collections.Generic.IList{Autodesk.Revit.DB.ElementFilter})
source: html/ce351a2d-c43e-e941-b28c-49726099c3a0.htm
---
# Autodesk.Revit.DB.LogicalAndFilter.#ctor Method

Constructs a new instance of the logical filter with any number of input filters.

## Syntax (C#)
```csharp
public LogicalAndFilter(
	IList<ElementFilter> filters
)
```

## Parameters
- **filters** (`System.Collections.Generic.IList < ElementFilter >`) - A collection of input filters.

## Remarks
The input filters will be copied.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The filter collection is empty, or contains invalid inputs.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

