---
kind: method
id: M:Autodesk.Revit.DB.Transform1D.#ctor(System.Double)
source: html/5a3a761b-a17d-8084-3dd4-8cf5832cf68f.htm
---
# Autodesk.Revit.DB.Transform1D.#ctor Method

Constructs the transformation by specifying the scale only.

## Syntax (C#)
```csharp
public Transform1D(
	double scale
)
```

## Parameters
- **scale** (`System.Double`) - The scale of the transformation.

## Remarks
The translation is set to zero.
 1D space is tranformed according to the following formula: t --> scale*t + translation
 This constructor sets translation to zero.

