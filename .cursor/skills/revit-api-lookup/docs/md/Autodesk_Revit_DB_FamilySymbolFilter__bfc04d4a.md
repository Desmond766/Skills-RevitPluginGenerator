---
kind: type
id: T:Autodesk.Revit.DB.FamilySymbolFilter
source: html/24cfdb4a-07e4-522d-4b9a-e0bba9387d5f.htm
---
# Autodesk.Revit.DB.FamilySymbolFilter

A filter used to find all family symbols of the given family.

## Syntax (C#)
```csharp
public class FamilySymbolFilter : ElementQuickFilter
```

## Remarks
This filter is a quick filter.
 Quick filters operate only on the ElementRecord, a low-memory class which has
 a limited interface to read element properties. Elements which are rejected
 by a quick filter will not be expanded in memory. Note that it may be faster to get a list of symbol ids from
 GetFamilySymbolIds () () () 
 rather than to iterate all of the contents of a document with this filter applied.

