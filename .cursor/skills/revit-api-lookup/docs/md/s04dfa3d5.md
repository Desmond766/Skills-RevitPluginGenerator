---
kind: type
id: T:Autodesk.Revit.DB.ElementCategoryFilter
source: html/b492ddf4-3058-8f9b-dfcc-8d5c4abb3605.htm
---
# Autodesk.Revit.DB.ElementCategoryFilter

A filter used to match elements by their category.

## Syntax (C#)
```csharp
public class ElementCategoryFilter : ElementQuickFilter
```

## Remarks
This filter is a quick filter.
 Quick filters operate only on the ElementRecord, a low-memory class which has
 a limited interface to read element properties. Elements which are rejected
 by a quick filter will not be expanded in memory.

