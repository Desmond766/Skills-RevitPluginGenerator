---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.SetParticipatesInWrapping(System.Int32,System.Boolean)
source: html/a0963e2b-4f8c-9117-a0cc-19da424e16d8.htm
---
# Autodesk.Revit.DB.CompoundStructure.SetParticipatesInWrapping Method

Assigns if a layer is included in wrapping at inserts and ends.

## Syntax (C#)
```csharp
public void SetParticipatesInWrapping(
	int layerIdx,
	bool participatesInWrapping
)
```

## Parameters
- **layerIdx** (`System.Int32`) - The index of the layer.
- **participatesInWrapping** (`System.Boolean`) - True if the specified layer will participate in wrapping at inserts and ends, false otherwise.

## Remarks
This method applies only to interior and exterior shell layers.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The wrapping of the layer is not valid.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The layer index is out of range.

