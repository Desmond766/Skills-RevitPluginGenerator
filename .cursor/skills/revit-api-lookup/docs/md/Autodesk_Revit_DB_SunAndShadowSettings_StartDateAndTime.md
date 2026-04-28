---
kind: property
id: P:Autodesk.Revit.DB.SunAndShadowSettings.StartDateAndTime
source: html/e50880d2-cab4-3cb5-56c8-6a7faaa0725b.htm
---
# Autodesk.Revit.DB.SunAndShadowSettings.StartDateAndTime Property

Identifies the start or current date and time.

## Syntax (C#)
```csharp
public DateTime StartDateAndTime { get; set; }
```

## Remarks
This property represents the start time for a single-day or multi-day study, or the current time
 for a still sun study. Note that Revit may ignore this value if the SunriseToSunset flag is set.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: Revit does not accept input DateTime objects if they are of kind DateTypeKind.Unspecified.

