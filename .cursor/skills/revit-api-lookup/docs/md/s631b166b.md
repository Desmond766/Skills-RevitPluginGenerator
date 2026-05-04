---
kind: type
id: T:Autodesk.Revit.DB.City
source: html/2ceeb3cd-05a1-02c6-3d95-ef689221acdc.htm
---
# Autodesk.Revit.DB.City

An object that contains geographical location information for a known city.

## Syntax (C#)
```csharp
public class City : APIObject
```

## Remarks
This object contains longitude, latitude, time zone information for a city already known by Revit.
Currently Revit does not the ability to add cities to the existing list. The list of known cities can be
retrieved using the Cities property on the application object.

