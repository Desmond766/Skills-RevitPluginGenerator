---
kind: property
id: P:Autodesk.Revit.DB.Leader.LeaderShape
source: html/3023f906-81ea-d4eb-4c4a-589853dcad2e.htm
---
# Autodesk.Revit.DB.Leader.LeaderShape Property

Geometric style of the leader

## Syntax (C#)
```csharp
public LeaderShape LeaderShape { get; }
```

## Remarks
While this property cannot be changed directly, it can change, with limitations,
 as an effect of other changes to either the leader itself or the annotation element
 the leader is associated with. For example, straight-line leaders have no elbow
 points; but if an elbow point is set for a straight leader, which is allowed, it will
 effectively change the leader's shape to a kinked line.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The leader is not currently owned by a valid element. A probable reason for that
 could be if the element has been independently deleted, or the leader has never
 been properly initialized.

