---
kind: method
id: M:Autodesk.Revit.DB.ElementClassFilter.#ctor(System.Type)
source: html/63806d36-c98c-a7c2-a149-8f32725d97f9.htm
---
# Autodesk.Revit.DB.ElementClassFilter.#ctor Method

Constructs a new instance of a filter to match elements by class.

## Syntax (C#)
```csharp
public ElementClassFilter(
	Type type
)
```

## Parameters
- **type** (`System.Type`) - The type to match.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input type is not a subclass of Element.
 -or-
 The input type is of an element class that exists in the API, but not in Revit's native object model.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

