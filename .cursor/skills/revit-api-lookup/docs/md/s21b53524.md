---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetMaterialId(System.Int32)
source: html/f5d0da40-935f-f18b-13e0-c4e5d8d8aca9.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetMaterialId Method

Retrieves the material element id of a specified layer.

## Syntax (C#)
```csharp
public ElementId GetMaterialId(
	int layerIdx
)
```

## Parameters
- **layerIdx** (`System.Int32`) - Index of a layer in the CompoundStructure.

## Returns
The material element id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The layer index is out of range.

