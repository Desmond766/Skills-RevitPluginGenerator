---
kind: property
id: P:Autodesk.Revit.DB.SunAndShadowSettings.EndDateAndTime
source: html/dff3f509-3f12-5323-6bb9-5d4e2b195800.htm
---
# Autodesk.Revit.DB.SunAndShadowSettings.EndDateAndTime Property

Identifies the end date and time.

## Syntax (C#)
```csharp
public DateTime EndDateAndTime { get; set; }
```

## Remarks
This property represents the end time for a single-day or multi-day study.
 The end date and time can be set for any study type, but is not always used.
 Note that Revit may ignore this value if the SunriseToSunset flag is set.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: Revit does not accept input DateTime objects if they are of kind DateTypeKind.Unspecified.

