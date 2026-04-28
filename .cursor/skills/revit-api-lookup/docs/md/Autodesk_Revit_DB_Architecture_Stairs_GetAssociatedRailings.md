---
kind: method
id: M:Autodesk.Revit.DB.Architecture.Stairs.GetAssociatedRailings
zh: 楼梯
source: html/e4907577-c0b1-fd40-3ae5-99f6b2d2558d.htm
---
# Autodesk.Revit.DB.Architecture.Stairs.GetAssociatedRailings Method

**中文**: 楼梯

Gets a list of the Railing elements which are associated to the boundaries of the stairs.

## Syntax (C#)
```csharp
public ICollection<ElementId> GetAssociatedRailings()
```

## Returns
The ids of the Railing elements.

## Remarks
This does not return railings which are sketched directly to the stairs (and are not
 associated to boundaries).

