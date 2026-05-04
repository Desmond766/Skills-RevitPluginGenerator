---
kind: method
id: M:Autodesk.Revit.DB.ElementMulticategoryFilter.#ctor(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/fb021210-3324-def7-23bd-cb437d2c29f8.htm
---
# Autodesk.Revit.DB.ElementMulticategoryFilter.#ctor Method

Constructs a new instance of a filter to find elements whose category matches any of a given set of categories.

## Syntax (C#)
```csharp
public ElementMulticategoryFilter(
	ICollection<ElementId> categoryIds
)
```

## Parameters
- **categoryIds** (`System.Collections.Generic.ICollection < ElementId >`) - The category ids to match.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more categories was not valid for filtering.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

