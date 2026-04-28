---
kind: method
id: M:Autodesk.Revit.DB.FilterableValueProvider.IsElementIdValueSupported(Autodesk.Revit.DB.Element)
source: html/8765d142-24d1-eff2-96f5-1bbaa88cc959.htm
---
# Autodesk.Revit.DB.FilterableValueProvider.IsElementIdValueSupported Method

Determines whether the provide can provide an ElementId value for the given element.

## Syntax (C#)
```csharp
public bool IsElementIdValueSupported(
	Element element
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The element to query.

## Returns
True if the provider can return an ElementId value for the given element, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

