---
kind: method
id: M:Autodesk.Revit.DB.Lighting.SpotLightDistribution.#ctor(System.Double,System.Double,System.Double)
source: html/546bf808-1ba7-7121-b83e-1e5101356788.htm
---
# Autodesk.Revit.DB.Lighting.SpotLightDistribution.#ctor Method

Creates a spot light distribution object with the given values.

## Syntax (C#)
```csharp
public SpotLightDistribution(
	double spotBeamAngle,
	double spotFieldAngle,
	double tiltAngle
)
```

## Parameters
- **spotBeamAngle** (`System.Double`) - The spot beam angle as a numerical value in radians between 0 and (8/9)*PI.
- **spotFieldAngle** (`System.Double`) - The spot field angle as a numerical value in radians between 0 and (8/9)*PI.
- **tiltAngle** (`System.Double`) - The tilt angle as a numerical value in radians between -PI and PI.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The angle is not valid because it is not between 1.0e-2 and 160.0.
 -or-
 The angle is not valid because it is not between -180.0 and 180.0.

