---
kind: type
id: T:Autodesk.Revit.DB.BuiltInParameter
source: html/fb011c91-be7e-f737-28c7-3f1e1917a0e0.htm
---
# Autodesk.Revit.DB.BuiltInParameter

An enumerated type listing all of the built-in parameter IDs supported by Autodesk
Revit.

## Syntax (C#)
```csharp
public enum BuiltInParameter
```

## Remarks
The ID of the parameter can be used to retrieve property values from an Element
by using the Element.Parameter property.
The documentation for each ID includes the parameter name, as found in the
Element Properties dialog in the English version of Autodesk Revit. Note that
multiple distinct parameter ids may map to the same English name; in those case you must 
examine the parameters associated with a specific element to determine
which parameter id to use.

