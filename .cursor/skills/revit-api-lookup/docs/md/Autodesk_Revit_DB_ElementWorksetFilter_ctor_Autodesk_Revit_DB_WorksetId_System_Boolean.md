---
kind: method
id: M:Autodesk.Revit.DB.ElementWorksetFilter.#ctor(Autodesk.Revit.DB.WorksetId,System.Boolean)
source: html/2dacae34-1350-94e3-3515-0734557d9774.htm
---
# Autodesk.Revit.DB.ElementWorksetFilter.#ctor Method

Constructs a new instance of a filter to match elements in a given workset.

## Syntax (C#)
```csharp
public ElementWorksetFilter(
	WorksetId worksetId,
	bool inverted
)
```

## Parameters
- **worksetId** (`Autodesk.Revit.DB.WorksetId`) - The workset id to match.
- **inverted** (`System.Boolean`) - True if the filter should match all elements which are not in the given workset.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

