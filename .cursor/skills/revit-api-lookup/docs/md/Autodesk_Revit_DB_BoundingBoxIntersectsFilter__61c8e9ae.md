---
kind: type
id: T:Autodesk.Revit.DB.BoundingBoxIntersectsFilter
source: html/1fbe1cff-ed94-4815-564b-05fd9e8f61fe.htm
---
# Autodesk.Revit.DB.BoundingBoxIntersectsFilter

A filter used to match elements with a bounding box that intersects the given Outline.

## Syntax (C#)
```csharp
public class BoundingBoxIntersectsFilter : ElementQuickFilter
```

## Remarks
This filter excludes all objects derived from View and objects derived from ElementType.
 This filter is a quick filter.
 Quick filters operate only on the ElementRecord, a low-memory class which has
 a limited interface to read element properties. Elements which are rejected
 by a quick filter will not be expanded in memory.

