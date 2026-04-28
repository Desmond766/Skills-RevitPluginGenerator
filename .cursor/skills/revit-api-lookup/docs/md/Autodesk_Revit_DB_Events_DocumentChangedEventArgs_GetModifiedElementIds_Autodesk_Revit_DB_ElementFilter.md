---
kind: method
id: M:Autodesk.Revit.DB.Events.DocumentChangedEventArgs.GetModifiedElementIds(Autodesk.Revit.DB.ElementFilter)
source: html/26a7eb5c-93c3-bc0c-b382-743b0acacbfa.htm
---
# Autodesk.Revit.DB.Events.DocumentChangedEventArgs.GetModifiedElementIds Method

Returns set of elements that were modified according to the given element filter.

## Syntax (C#)
```csharp
public ICollection<ElementId> GetModifiedElementIds(
	ElementFilter filter
)
```

## Parameters
- **filter** (`Autodesk.Revit.DB.ElementFilter`) - The element filter to be applied.

## Returns
The set of ElementId for modified elements that pass the filter.
 Returns empty set if no elements are found which pass the filter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

