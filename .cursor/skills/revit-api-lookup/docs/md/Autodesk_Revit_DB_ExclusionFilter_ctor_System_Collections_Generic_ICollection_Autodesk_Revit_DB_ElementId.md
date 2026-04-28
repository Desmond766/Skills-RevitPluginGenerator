---
kind: method
id: M:Autodesk.Revit.DB.ExclusionFilter.#ctor(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/2080323d-fe5e-eead-6abc-3ae27eff00dd.htm
---
# Autodesk.Revit.DB.ExclusionFilter.#ctor Method

Constructs a new instance of a filter to exclude elements automatically.

## Syntax (C#)
```csharp
public ExclusionFilter(
	ICollection<ElementId> idsToExclude
)
```

## Parameters
- **idsToExclude** (`System.Collections.Generic.ICollection < ElementId >`) - The ids to exclude from the results.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input collection of ids was empty, or its contents were not valid for iteration.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

