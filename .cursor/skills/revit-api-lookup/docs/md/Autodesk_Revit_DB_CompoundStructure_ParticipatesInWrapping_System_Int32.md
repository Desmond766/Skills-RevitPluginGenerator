---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.ParticipatesInWrapping(System.Int32)
source: html/06cfa919-0839-7771-2ff1-02c43465daad.htm
---
# Autodesk.Revit.DB.CompoundStructure.ParticipatesInWrapping Method

Identifies if a layer is included in wrapping at inserts and ends.

## Syntax (C#)
```csharp
public bool ParticipatesInWrapping(
	int layerIdx
)
```

## Parameters
- **layerIdx** (`System.Int32`) - The index of the layer.

## Returns
If true, then the layer participates in wrapping at inserts and openings. If false, the layer will not
 participate in wrapping.

## Remarks
This method applies only to interior and exterior shell layers.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The layer index is out of range.

