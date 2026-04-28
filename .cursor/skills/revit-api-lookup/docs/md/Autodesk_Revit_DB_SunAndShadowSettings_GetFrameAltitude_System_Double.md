---
kind: method
id: M:Autodesk.Revit.DB.SunAndShadowSettings.GetFrameAltitude(System.Double)
source: html/6150a802-4969-342a-4b5b-0bc7834f0fa0.htm
---
# Autodesk.Revit.DB.SunAndShadowSettings.GetFrameAltitude Method

Identifies the altitude of the sun (angle in radians) for a specific frame.

## Syntax (C#)
```csharp
public double GetFrameAltitude(
	double frame
)
```

## Parameters
- **frame** (`System.Double`) - Frame for which time is requested

## Returns
Altitude angle (radians)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - the frame value frame is not valid.

