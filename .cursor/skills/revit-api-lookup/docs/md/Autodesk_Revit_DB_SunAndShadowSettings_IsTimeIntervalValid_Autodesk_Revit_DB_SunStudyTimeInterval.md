---
kind: method
id: M:Autodesk.Revit.DB.SunAndShadowSettings.IsTimeIntervalValid(Autodesk.Revit.DB.SunStudyTimeInterval)
source: html/74661a1d-f8c1-1929-cb22-e8407ca1e1bc.htm
---
# Autodesk.Revit.DB.SunAndShadowSettings.IsTimeIntervalValid Method

Checks whether the time interval is valid for the SunAndShadowType.

## Syntax (C#)
```csharp
public bool IsTimeIntervalValid(
	SunStudyTimeInterval interval
)
```

## Parameters
- **interval** (`Autodesk.Revit.DB.SunStudyTimeInterval`) - Time interval value.

## Returns
True if the time interval is valid for the current SunAndShadowType, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

