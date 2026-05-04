---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementCollector.#ctor(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
zh: 筛选、过滤
source: html/901f78a0-1f6c-217b-ea48-8b404324e88b.htm
---
# Autodesk.Revit.DB.FilteredElementCollector.#ctor Method

**中文**: 筛选、过滤

Constructs a new FilteredElementCollector that will search and filter a specified set of elements.

## Syntax (C#)
```csharp
public FilteredElementCollector(
	Document document,
	ICollection<ElementId> elementIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that owns the elements matching the element ids.
- **elementIds** (`System.Collections.Generic.ICollection < ElementId >`) - The input set of element ids.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input collection of ids was empty, or its contents were not valid for iteration.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

