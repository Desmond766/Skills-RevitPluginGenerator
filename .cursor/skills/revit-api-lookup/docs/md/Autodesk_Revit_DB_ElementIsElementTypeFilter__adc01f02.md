---
kind: type
id: T:Autodesk.Revit.DB.ElementIsElementTypeFilter
source: html/607fd199-b1ba-f21f-ad98-33b65fbf5fe5.htm
---
# Autodesk.Revit.DB.ElementIsElementTypeFilter

A filter used to match elements which are ElementTypes.

## Syntax (C#)
```csharp
public class ElementIsElementTypeFilter : ElementQuickFilter
```

## Remarks
This filter is a quick filter.
 Quick filters operate only on the ElementRecord, a low-memory class which has
 a limited interface to read element properties. Elements which are rejected
 by a quick filter will not be expanded in memory.

