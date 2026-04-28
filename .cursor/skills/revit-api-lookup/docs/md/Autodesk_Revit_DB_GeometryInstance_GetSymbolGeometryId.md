---
kind: method
id: M:Autodesk.Revit.DB.GeometryInstance.GetSymbolGeometryId
source: html/28708c47-a358-41b3-d754-dda20f01ac6c.htm
---
# Autodesk.Revit.DB.GeometryInstance.GetSymbolGeometryId Method

Gets the SymbolGeometryId that contains data about the symbol of this instance.

## Syntax (C#)
```csharp
public SymbolGeometryId GetSymbolGeometryId()
```

## Returns
Returns the SymbolGeometryId that contains data about the symbol of this instance.

## Remarks
Use the strings returned by SymbolGeometryId.AsIdentifier(bool) to check if two GeometryInstance point to the same geometry of the symbol.

