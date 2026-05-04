---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetLayers
source: html/105b59e9-9cea-1988-a5a7-cc9cde49145c.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetLayers Method

A copy of the layers which define this compound structure.

## Syntax (C#)
```csharp
public IList<CompoundStructureLayer> GetLayers()
```

## Returns
The layers, returned in order (Exterior to Interior for walls, top to bottom for roofs, floors or ceilings). The index of each layer in this array
 can be used in other CompoundStructure methods accepting a layer index.

