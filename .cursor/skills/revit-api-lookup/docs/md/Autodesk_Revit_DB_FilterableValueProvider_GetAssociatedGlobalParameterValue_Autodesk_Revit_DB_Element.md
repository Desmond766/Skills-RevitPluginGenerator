---
kind: method
id: M:Autodesk.Revit.DB.FilterableValueProvider.GetAssociatedGlobalParameterValue(Autodesk.Revit.DB.Element)
source: html/f66d222e-0b19-86fe-2c55-81745329bfcb.htm
---
# Autodesk.Revit.DB.FilterableValueProvider.GetAssociatedGlobalParameterValue Method

Gets a global parameter value associated with a parameter from the given element.

## Syntax (C#)
```csharp
public ElementId GetAssociatedGlobalParameterValue(
	Element element
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The element to query.

## Returns
The associated global parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

