---
kind: type
id: T:Autodesk.Revit.DB.BoundingBoxContainsPointFilter
source: html/a5ea9f5a-ddba-9db7-eaa0-2b37098f0142.htm
---
# Autodesk.Revit.DB.BoundingBoxContainsPointFilter

A filter used to match elements with a bounding box that contains the given point.

## Syntax (C#)
```csharp
public class BoundingBoxContainsPointFilter : ElementQuickFilter
```

## Remarks
This filter excludes all objects derived from View and objects derived from ElementType.
 This filter is a quick filter.
 Quick filters operate only on the ElementRecord, a low-memory class which has
 a limited interface to read element properties. Elements which are rejected
 by a quick filter will not be expanded in memory.

