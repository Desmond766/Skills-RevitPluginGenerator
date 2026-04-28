---
kind: method
id: M:Autodesk.Revit.DB.SunAndShadowSettings.GetSunrise(System.DateTime)
source: html/5ed2edef-f53c-0fcb-010d-f4a33d685fba.htm
---
# Autodesk.Revit.DB.SunAndShadowSettings.GetSunrise Method

Identifies the sunrise time for the SunAndShadowSettings element at its current location
 and indicated date.

## Syntax (C#)
```csharp
public DateTime GetSunrise(
	DateTime date
)
```

## Parameters
- **date** (`System.DateTime`) - The date for which to determine sunrise time.

## Returns
The date and time. The value will be in Coordinated Universal Time (UTC).

## Remarks
The value returned is affected by the value of the UsesDST 
 flag set for the current location. If this value is true, the sunrise value will be adjusted for
 Daylight Savings Time, regardless of the value of the input date.

