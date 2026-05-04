---
kind: method
id: M:Autodesk.Revit.DB.Lighting.InitialIlluminanceIntensity.#ctor(System.Double,System.Double)
source: html/8d018048-1258-c4b3-4a2f-501f3ee07844.htm
---
# Autodesk.Revit.DB.Lighting.InitialIlluminanceIntensity.#ctor Method

Creates an initial illuminance intensity object with the given document and illuminance values.

## Syntax (C#)
```csharp
public InitialIlluminanceIntensity(
	double distance,
	double illuminance
)
```

## Parameters
- **distance** (`System.Double`) - The illuminance distance value in feet as a numerical value between 0 and 1e+30.
- **illuminance** (`System.Double`) - The illuminance value in lx as a numerical value between 0 and 1e+30.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The distance value is not valid because it is not between 0 and 1e+30.
 -or-
 The illuminance value is not valid because it is not between 0 and 1e+30.

