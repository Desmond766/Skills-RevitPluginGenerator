---
kind: method
id: M:Autodesk.Revit.DB.SunAndShadowSettings.GetFrameTime(System.Double)
source: html/59465c30-c6a5-d5a7-0d40-0c05ea64b60d.htm
---
# Autodesk.Revit.DB.SunAndShadowSettings.GetFrameTime Method

Identifies the date and time of the SunAndShadowSettings element for a given frame.

## Syntax (C#)
```csharp
public DateTime GetFrameTime(
	double frame
)
```

## Parameters
- **frame** (`System.Double`) - Frame for which time is requested

## Returns
The date and time. The value will be in Coordinated Universal Time (UTC).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - the frame value frame is not valid.

