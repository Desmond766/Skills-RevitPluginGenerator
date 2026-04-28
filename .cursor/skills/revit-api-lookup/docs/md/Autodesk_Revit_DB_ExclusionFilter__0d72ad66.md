---
kind: type
id: T:Autodesk.Revit.DB.ExclusionFilter
source: html/28581bc9-42ad-9178-edcc-e33f42090bc9.htm
---
# Autodesk.Revit.DB.ExclusionFilter

A filter used to exclude a set of elements automatically.

## Syntax (C#)
```csharp
public class ExclusionFilter : ElementQuickFilter
```

## Remarks
This filter is a quick filter.
 Quick filters operate only on the ElementRecord, a low-memory class which has
 a limited interface to read element properties. Elements which are rejected
 by a quick filter will not be expanded in memory.

