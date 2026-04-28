---
kind: method
id: M:Autodesk.Revit.DB.SunAndShadowSettings.GetFrameAzimuth(System.Double)
source: html/e0eea2bf-5dd0-4337-46c1-fb9755c47457.htm
---
# Autodesk.Revit.DB.SunAndShadowSettings.GetFrameAzimuth Method

Identifies the azimuth of the sun (angle in radians) for a specific frame.

## Syntax (C#)
```csharp
public double GetFrameAzimuth(
	double frame
)
```

## Parameters
- **frame** (`System.Double`) - Frame for which time is requested

## Returns
Azimuth angle (radians). This is measured counterclockwise from the X axis (East direction). Note that this
 is a different frame of reference than is used by Revit for the Lighting Study Azimuth value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - the frame value frame is not valid.

