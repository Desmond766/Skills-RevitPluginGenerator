---
kind: property
id: P:Autodesk.Revit.DB.WallSweepInfo.IsFixed
source: html/938549e8-c6f0-76c8-d640-ab2763d6b899.htm
---
# Autodesk.Revit.DB.WallSweepInfo.IsFixed Property

Indicates if the described wall sweep is fixed. A sweep is fixed if it is a part of a vertical compound structure.

## Syntax (C#)
```csharp
public bool IsFixed { get; }
```

## Remarks
Wall sweeps from the definition of a vertical compound structure are fixed based on the wall type's definition.
 They are not permitted to be moved by users.
 Other wall sweeps defined outside of CompoundStructure by UI or API are permitted to be moved.

