---
kind: method
id: M:Autodesk.Revit.DB.FilterableValueProvider.IsIntegerValueSupported(Autodesk.Revit.DB.Element)
source: html/9ed4ea4d-7d32-8e10-6f9e-f501a038b92e.htm
---
# Autodesk.Revit.DB.FilterableValueProvider.IsIntegerValueSupported Method

Determines whether the provide can provide an integer value for the given element.

## Syntax (C#)
```csharp
public bool IsIntegerValueSupported(
	Element element
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The element to query.

## Returns
True if the provider can return an integer value for the given element, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

