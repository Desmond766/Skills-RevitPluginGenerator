---
kind: method
id: M:Autodesk.Revit.DB.Events.DocumentChangedEventArgs.GetAddedElementIds(Autodesk.Revit.DB.ElementFilter)
source: html/a04a4dac-41b3-cd01-6ceb-dfeae63d6b7a.htm
---
# Autodesk.Revit.DB.Events.DocumentChangedEventArgs.GetAddedElementIds Method

Returns set of newly added elements that pass the filter.

## Syntax (C#)
```csharp
public ICollection<ElementId> GetAddedElementIds(
	ElementFilter filter
)
```

## Parameters
- **filter** (`Autodesk.Revit.DB.ElementFilter`) - The element filter to be applied.

## Returns
The set of ElementId for newly added elements that pass the filter.
 Returns empty set if no elements are found which pass the filter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

