---
kind: method
id: M:Autodesk.Revit.DB.ElementMulticlassFilter.#ctor(System.Collections.Generic.IList{System.Type},System.Boolean)
source: html/7988f4fa-643d-7f7d-6a86-efd030bea11c.htm
---
# Autodesk.Revit.DB.ElementMulticlassFilter.#ctor Method

Constructs a new instance of a filter to find elements whose Element subclasses matches any of a given set of input classes, with an option to instead match
 elements whose Element subclass does not match the list of input classes.

## Syntax (C#)
```csharp
public ElementMulticlassFilter(
	IList<Type> typeList,
	bool inverted
)
```

## Parameters
- **typeList** (`System.Collections.Generic.IList < Type >`) - The list of Element subclass types to match.
- **inverted** (`System.Boolean`) - True if the filter should match all elements which are not of the given Element subclass.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more input types are not valid subclasses of Element for this filter.
 -or-
 One or more of the types do not exist in Revit's native object model.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

