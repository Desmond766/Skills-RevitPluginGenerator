---
kind: property
id: P:Autodesk.Revit.DB.SiteLocation.TimeZone
source: html/6718329d-34ff-7d63-173a-c61905639807.htm
---
# Autodesk.Revit.DB.SiteLocation.TimeZone Property

The time-zone for the site.

## Syntax (C#)
```csharp
public double TimeZone { get; set; }
```

## Remarks
Remarks A property that returns the time zone in which the site resides.
 The value is in hours, ranging from +12 hours to -12 hours with 0 being GMT.
 If the input value is not in the valid range, it will be shifted by multiples
 of 24 until it is in range. Set this property directly if for your desired latitude and longitude, Revit's calculation
 does not match with the actual time zone for your location. Note that there are no restrictions
 preventing you from setting this to an incorrect value for the site location, and incorrect
 times for Solar Studies may result.

