---
kind: property
id: P:Autodesk.Revit.DB.SunAndShadowSettings.TimeInterval
source: html/6c98d4af-72bc-07dc-1920-ff9909f0486a.htm
---
# Autodesk.Revit.DB.SunAndShadowSettings.TimeInterval Property

Identifies the time interval between animation frames.

## Syntax (C#)
```csharp
public SunStudyTimeInterval TimeInterval { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: the time interval value interval is not valid for the current SunAndShadowType.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

