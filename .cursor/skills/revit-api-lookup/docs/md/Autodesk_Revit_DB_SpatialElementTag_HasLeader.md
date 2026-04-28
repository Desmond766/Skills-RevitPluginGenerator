---
kind: property
id: P:Autodesk.Revit.DB.SpatialElementTag.HasLeader
source: html/645e86f1-72c0-00b4-ac36-f5e09a9be15f.htm
---
# Autodesk.Revit.DB.SpatialElementTag.HasLeader Property

Identifies if a leader is displayed for the tag or not.

## Syntax (C#)
```csharp
public bool HasLeader { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: SpatialElementTag is orphaned.
 -or-
 When setting this property: Thrown when attempting to turn off leader of the pinned tag
 when the tag's head position is located outside off the host element.

