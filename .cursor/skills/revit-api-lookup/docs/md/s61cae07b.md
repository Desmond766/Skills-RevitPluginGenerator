---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetLayerWidth(System.Int32)
source: html/47ba99b2-d633-bcc7-f9a7-fe6c00bc5af0.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetLayerWidth Method

Retrieves the width of a specified layer.

## Syntax (C#)
```csharp
public double GetLayerWidth(
	int layerIdx
)
```

## Parameters
- **layerIdx** (`System.Int32`) - Index of a layer in the CompoundStructure.

## Returns
The width of the specified layer.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The layer index is out of range.

