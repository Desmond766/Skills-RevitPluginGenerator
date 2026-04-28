---
kind: type
id: T:Autodesk.Revit.DB.ElementMulticategoryFilter
source: html/8d2774eb-3c47-5c3d-2866-8d4ab7408d2d.htm
---
# Autodesk.Revit.DB.ElementMulticategoryFilter

A filter used to find elements whose category matches any of a given set of categories.

## Syntax (C#)
```csharp
public class ElementMulticategoryFilter : ElementQuickFilter
```

## Remarks
This filter is a quick filter.
 Quick filters operate only on the ElementRecord, a low-memory class which has
 a limited interface to read element properties. Elements which are rejected
 by a quick filter will not be expanded in memory.

