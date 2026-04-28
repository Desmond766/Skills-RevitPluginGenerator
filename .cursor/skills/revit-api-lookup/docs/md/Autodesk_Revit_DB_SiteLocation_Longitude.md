---
kind: property
id: P:Autodesk.Revit.DB.SiteLocation.Longitude
source: html/f8183a87-88ed-234b-c91c-cb7775a87a7f.htm
---
# Autodesk.Revit.DB.SiteLocation.Longitude Property

The longitude of the site location.

## Syntax (C#)
```csharp
public double Longitude { get; set; }
```

## Remarks
A property that contains the longitude of the site location.
 The value of this property is in radians between +PI and -PI. If the given value is
 not between -PI and PI, it will be shifted by multiples of 2PI until it is in range. When setting this property:
 Revit will attempt to match the coordinates to a city it knows about, and if a match is found, will set the
 name accordingly. Revit will attempt to automatically adjust the time zone value to match the new Longitude value set using
 [!:Autodesk::Revit::DB::SunAndShadowSettings::CalculateTimeZone] . For some boundary
 cases, the time zone calculated may not be correct. You can set the TimeZone property directly to the correct
 value if necessary.
 Revit will attempt to automatically update the weather station associated with the coordinates.

