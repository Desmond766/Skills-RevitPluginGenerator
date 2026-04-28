---
kind: method
id: M:Autodesk.Revit.DB.FilterableValueProvider.IsDoubleValueSupported(Autodesk.Revit.DB.Element)
source: html/0ae156db-10dc-1085-6349-0e04e9732b74.htm
---
# Autodesk.Revit.DB.FilterableValueProvider.IsDoubleValueSupported Method

Determines whether the provide can provide a double-precision numeric value for the given element.

## Syntax (C#)
```csharp
public bool IsDoubleValueSupported(
	Element element
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The element to query.

## Returns
True if the provider can return a double-precision numeric value for the given element, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

