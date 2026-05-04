---
kind: method
id: M:Autodesk.Revit.DB.WallSweep.GetHostIds
source: html/d1db8e46-2fea-5b9c-a5c1-cdc8c519a56e.htm
---
# Autodesk.Revit.DB.WallSweep.GetHostIds Method

Gets a list of all host walls on which the sweep resides.

## Syntax (C#)
```csharp
public IList<ElementId> GetHostIds()
```

## Returns
The list of wall ids.

## Remarks
Fixed wall sweeps from vertically compound structures will return only one host element.

