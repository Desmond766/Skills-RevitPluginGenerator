---
kind: property
id: P:Autodesk.Revit.DB.SiteLocation.Latitude
source: html/0e39fbc4-e7c6-0c26-b7b3-70b4028fa927.htm
---
# Autodesk.Revit.DB.SiteLocation.Latitude Property

The latitude of the site location.

## Syntax (C#)
```csharp
public double Latitude { get; set; }
```

## Remarks
A property that contains the latitude of the site location.
 The value of this property is in radians between +PI/2 and -PI/2. When setting this property:
 Revit will attempt to match the coordinates to a city it knows about, and if a match is found, will set the
 name accordingly. Revit will attempt to automatically adjust the time zone value to match the new Latitude value set using
 [!:Autodesk::Revit::DB::SunAndShadowSettings::CalculateTimeZone] . For some boundary
 cases, the time zone calculated may not be correct. You can set the TimeZone property directly to the
 correct value if necessary.
 Revit will attempt to automatically update the weather station associated with the location's coordinates.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The latitude value is out of range. It must be between -PI/2 and PI/2.

