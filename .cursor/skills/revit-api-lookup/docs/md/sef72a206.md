---
kind: method
id: M:Autodesk.Revit.DB.ElementMulticlassFilter.#ctor(System.Collections.Generic.IList{System.Type})
source: html/6d3c931c-81a3-4b6f-d9ac-e2e714c93db1.htm
---
# Autodesk.Revit.DB.ElementMulticlassFilter.#ctor Method

Constructs a new instance of a filter to find elements whose Element subclasses matches any of a given set of input classes.

## Syntax (C#)
```csharp
public ElementMulticlassFilter(
	IList<Type> typeList
)
```

## Parameters
- **typeList** (`System.Collections.Generic.IList < Type >`) - The list of Element subclass types to match.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more input types are not valid subclasses of Element for this filter.
 -or-
 One or more of the types do not exist in Revit's native object model.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

