---
kind: type
id: T:Autodesk.Revit.DB.BoundingBoxIsInsideFilter
source: html/eb8735d7-28fc-379d-9de9-1e02326851f5.htm
---
# Autodesk.Revit.DB.BoundingBoxIsInsideFilter

A filter used to match elements with a bounding box that is contained by the given Outline.

## Syntax (C#)
```csharp
public class BoundingBoxIsInsideFilter : ElementQuickFilter
```

## Remarks
This filter excludes all objects derived from View and objects derived from ElementType.
 This filter is a quick filter.
 Quick filters operate only on the ElementRecord, a low-memory class which has
 a limited interface to read element properties. Elements which are rejected
 by a quick filter will not be expanded in memory.

