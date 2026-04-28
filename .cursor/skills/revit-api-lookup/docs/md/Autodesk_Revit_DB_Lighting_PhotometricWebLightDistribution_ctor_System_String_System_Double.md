---
kind: method
id: M:Autodesk.Revit.DB.Lighting.PhotometricWebLightDistribution.#ctor(System.String,System.Double)
source: html/218d088b-6601-cf37-1a20-c33c4b283ccf.htm
---
# Autodesk.Revit.DB.Lighting.PhotometricWebLightDistribution.#ctor Method

Creates a photometric web light distribution object with the given filename and tilt.

## Syntax (C#)
```csharp
public PhotometricWebLightDistribution(
	string photometricWebFile,
	double tiltAngle
)
```

## Parameters
- **photometricWebFile** (`System.String`) - The filename of the IES file to use.
- **tiltAngle** (`System.Double`) - The tilt angle as a numerical value in degrees between -180.0 and 180.0.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The angle is not valid because it is not between -180.0 and 180.0.

