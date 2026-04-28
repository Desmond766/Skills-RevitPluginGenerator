---
kind: method
id: M:Autodesk.Revit.DB.InstanceNode.GetSymbolGeometryId
source: html/6e6cbd6a-493f-7329-83e2-c28b333eede8.htm
---
# Autodesk.Revit.DB.InstanceNode.GetSymbolGeometryId Method

Gets the SymbolGeometryId associated with the node.

## Syntax (C#)
```csharp
public SymbolGeometryId GetSymbolGeometryId()
```

## Remarks
Use the strings returned by SymbolGeometryId.AsIdentifier(bool) to check if two nodes point to the same geometry of the symbol.

