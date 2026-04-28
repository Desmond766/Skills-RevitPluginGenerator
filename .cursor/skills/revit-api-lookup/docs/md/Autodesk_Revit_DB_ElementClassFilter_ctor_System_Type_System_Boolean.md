---
kind: method
id: M:Autodesk.Revit.DB.ElementClassFilter.#ctor(System.Type,System.Boolean)
source: html/9c7f7906-5c4b-7825-584b-9fd599f560f1.htm
---
# Autodesk.Revit.DB.ElementClassFilter.#ctor Method

Constructs a new instance of a filter to match elements by class, with the option to match all elements which are not of the given class.

## Syntax (C#)
```csharp
public ElementClassFilter(
	Type type,
	bool inverted
)
```

## Parameters
- **type** (`System.Type`) - The type to match.
- **inverted** (`System.Boolean`) - True if the filter should match all elements which are not of the given class.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input type is not a subclass of Element.
 -or-
 The input type is of an element class that exists in the API, but not in Revit's native object model.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

