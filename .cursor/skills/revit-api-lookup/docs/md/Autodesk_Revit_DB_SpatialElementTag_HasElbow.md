---
kind: property
id: P:Autodesk.Revit.DB.SpatialElementTag.HasElbow
source: html/3a30f767-9284-8287-ba2f-dc1660c368b8.htm
---
# Autodesk.Revit.DB.SpatialElementTag.HasElbow Property

Identifies if the tag's leader has an elbow point or not.

## Syntax (C#)
```csharp
public bool HasElbow { get; }
```

## Remarks
Straight leaders do not have elbow points. Use LeaderElbow to get or set elbow point.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no leader for this tag.

