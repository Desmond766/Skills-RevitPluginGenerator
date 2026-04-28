---
kind: type
id: T:Autodesk.Revit.DB.ElementMulticlassFilter
source: html/acb0ecb3-afcb-4e94-641d-450716e9ac73.htm
---
# Autodesk.Revit.DB.ElementMulticlassFilter

A filter used to match elements by their class, where more than one class of element may be passed.

## Syntax (C#)
```csharp
public class ElementMulticlassFilter : ElementQuickFilter
```

## Remarks
This filter is a quick filter.
 Quick filters operate only on the ElementRecord, a low-memory class which has
 a limited interface to read element properties. Elements which are rejected
 by a quick filter will not be expanded in memory.
 Only elements whose class is an exact match to one of the input classes,
 or elements whose type is derived from the input class will pass the collector. There is a small subset of Element subclasses in the API that are not supported
 by this filter. These classes exist in the API, but not in Revit's native object model,
 which means that this filter doesn't support them. In order to use a class filter to
 find elements of these types, it is necessary to use a higher level class and then
 process the results further to find elements matching only the subclass. For a list
 of subclasses affected by this restriction, consult the documentation for [!:Autodesk::Revit::DB::ElementClassFilter] .

