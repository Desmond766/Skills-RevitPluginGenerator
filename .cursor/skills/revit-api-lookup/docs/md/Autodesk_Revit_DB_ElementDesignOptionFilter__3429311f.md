---
kind: type
id: T:Autodesk.Revit.DB.ElementDesignOptionFilter
source: html/bde93f54-1852-8a32-aca5-a1c23e607b91.htm
---
# Autodesk.Revit.DB.ElementDesignOptionFilter

A filter used to find elements contained within a particular design option.

## Syntax (C#)
```csharp
public class ElementDesignOptionFilter : ElementQuickFilter
```

## Remarks
This filter is a quick filter.
 Quick filters operate only on the ElementRecord, a low-memory class which has
 a limited interface to read element properties. Elements which are rejected
 by a quick filter will not be expanded in memory.

