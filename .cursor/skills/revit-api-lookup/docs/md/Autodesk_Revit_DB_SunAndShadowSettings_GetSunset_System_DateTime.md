---
kind: method
id: M:Autodesk.Revit.DB.SunAndShadowSettings.GetSunset(System.DateTime)
source: html/a8f1a800-1d06-b994-09f7-fc94474416b0.htm
---
# Autodesk.Revit.DB.SunAndShadowSettings.GetSunset Method

Identifies the sunset time for the SunAndShadowSettings element at its current location
 and indicated date.

## Syntax (C#)
```csharp
public DateTime GetSunset(
	DateTime date
)
```

## Parameters
- **date** (`System.DateTime`) - The date for which to determine sunset time.

## Returns
The date and time. The value will be in Coordinated Universal Time (UTC).

## Remarks
The value returned is affected by the value of the UsesDST 
 flag set for the current location. If this value is true, the sunset value will be adjusted for
 Daylight Savings Time, regardless of the value of the input date.

