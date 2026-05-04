---
kind: type
id: T:Autodesk.Revit.DB.ElementIdSetFilter
source: html/b13469b1-1ef3-23af-feb5-4dc847ab6359.htm
---
# Autodesk.Revit.DB.ElementIdSetFilter

A filter wrapping a set of elements.

## Syntax (C#)
```csharp
public class ElementIdSetFilter : ElementQuickFilter
```

## Remarks
This filter is a quick filter.
 Quick filters operate only on the ElementRecord, a low-memory class which has
 a limited interface to read element properties. Elements which are rejected
 by a quick filter will not be expanded in memory.

