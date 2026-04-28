---
kind: method
id: M:Autodesk.Revit.DB.ElementFilter.PassesFilter(Autodesk.Revit.DB.Element)
source: html/1402f6e0-995c-2644-c7a9-7016a81a4ef4.htm
---
# Autodesk.Revit.DB.ElementFilter.PassesFilter Method

Applies the filter to a given element.

## Syntax (C#)
```csharp
public bool PassesFilter(
	Element element
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The element.

## Returns
True if the element is accepted by the filter. False if the element is rejected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

