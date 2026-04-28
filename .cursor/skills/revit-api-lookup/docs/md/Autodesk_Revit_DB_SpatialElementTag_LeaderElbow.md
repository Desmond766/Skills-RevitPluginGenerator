---
kind: property
id: P:Autodesk.Revit.DB.SpatialElementTag.LeaderElbow
source: html/8c75fb6c-8b26-077b-125e-b4e2bce3d230.htm
---
# Autodesk.Revit.DB.SpatialElementTag.LeaderElbow Property

The position of the leader's elbow (middle point).

## Syntax (C#)
```csharp
public XYZ LeaderElbow { get; set; }
```

## Remarks
Returns the elbow point of the tag leader.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no leader for this tag.
 -or-
 When setting this property: SpatialElementTag is pinned.
 -or-
 When setting this property: SpatialElementTag is orphaned.

