---
kind: method
id: M:Autodesk.Revit.DB.Transform1D.#ctor(System.Double,System.Double)
source: html/3be46c98-e6ee-21a2-fcb5-18f5e24d78af.htm
---
# Autodesk.Revit.DB.Transform1D.#ctor Method

Constructs the transformation by specifying the scale and the translation.

## Syntax (C#)
```csharp
public Transform1D(
	double scale,
	double translation
)
```

## Parameters
- **scale** (`System.Double`) - The scale of the transformation.
- **translation** (`System.Double`) - The translational part of the transformation.

## Remarks
1D space is tranformed according to the following formula: t --> scale*t + translation

