---
kind: method
id: M:Autodesk.Revit.DB.FilterableValueProvider.IsStringValueSupported(Autodesk.Revit.DB.Element)
source: html/6a2d183c-34a8-69ad-a337-85dfba932f1c.htm
---
# Autodesk.Revit.DB.FilterableValueProvider.IsStringValueSupported Method

Determines whether the provide can provide a string value for the given element.

## Syntax (C#)
```csharp
public bool IsStringValueSupported(
	Element element
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The element to query.

## Returns
True if the provider can return a string value for the given element, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

