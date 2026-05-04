---
kind: type
id: T:Autodesk.Revit.DB.ElementStructuralTypeFilter
source: html/e9b102e4-ef0d-15c7-98e9-e5887050d301.htm
---
# Autodesk.Revit.DB.ElementStructuralTypeFilter

A filter used to find elements matching a structural type.

## Syntax (C#)
```csharp
public class ElementStructuralTypeFilter : ElementQuickFilter
```

## Remarks
This filter is a quick filter.
 Quick filters operate only on the ElementRecord, a low-memory class which has
 a limited interface to read element properties. Elements which are rejected
 by a quick filter will not be expanded in memory.

