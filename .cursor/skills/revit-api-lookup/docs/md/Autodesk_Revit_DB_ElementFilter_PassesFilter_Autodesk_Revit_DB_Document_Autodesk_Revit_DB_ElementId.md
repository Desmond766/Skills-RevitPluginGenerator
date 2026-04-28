---
kind: method
id: M:Autodesk.Revit.DB.ElementFilter.PassesFilter(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/a8e86084-b91f-c3cf-c334-e163168328d6.htm
---
# Autodesk.Revit.DB.ElementFilter.PassesFilter Method

Applies the filter to a given element.

## Syntax (C#)
```csharp
public bool PassesFilter(
	Document document,
	ElementId id
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **id** (`Autodesk.Revit.DB.ElementId`) - The element id.

## Returns
True if the element is accepted by the filter. False if the element is rejected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

