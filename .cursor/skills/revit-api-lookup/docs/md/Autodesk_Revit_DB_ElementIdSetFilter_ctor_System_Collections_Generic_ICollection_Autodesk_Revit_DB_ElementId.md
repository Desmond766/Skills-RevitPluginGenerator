---
kind: method
id: M:Autodesk.Revit.DB.ElementIdSetFilter.#ctor(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/32c0f42b-04aa-5c4d-27d3-bb6f72180247.htm
---
# Autodesk.Revit.DB.ElementIdSetFilter.#ctor Method

Constructs a new instance of a filter wrapping a set of elements.

## Syntax (C#)
```csharp
public ElementIdSetFilter(
	ICollection<ElementId> idsToInclude
)
```

## Parameters
- **idsToInclude** (`System.Collections.Generic.ICollection < ElementId >`) - The ids.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input collection of ids was empty, or its contents were not valid for iteration.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

