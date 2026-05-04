---
kind: method
id: M:Autodesk.Revit.DB.SunAndShadowSettings.CalculateTimeZone(System.Double,System.Double)
source: html/2206c828-d85c-d54b-73f1-471e67a3ce36.htm
---
# Autodesk.Revit.DB.SunAndShadowSettings.CalculateTimeZone Method

Use Revit's utilities to calculate the time zone for a given longitude and latitude.

## Syntax (C#)
```csharp
public static double CalculateTimeZone(
	double latitude,
	double longitude
)
```

## Parameters
- **latitude** (`System.Double`) - The latitude.
- **longitude** (`System.Double`) - The longitude.

## Returns
The time zone, in hours, ranging from +12 hours to -12 hours with 0 being GMT.

## Remarks
For some latitude and longitude boundary cases, the time zone calculated may not be correct.
 The API offers the ability to adjust the time zone independent of Revit's calculations for situations
 where this happens.

