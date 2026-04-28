---
kind: method
id: M:Autodesk.Revit.DB.SiteLocation.SetGeoCoordinateSystem(System.String)
source: html/d7b1a7b0-5e52-46e3-cef0-d1e2e017122a.htm
---
# Autodesk.Revit.DB.SiteLocation.SetGeoCoordinateSystem Method

Set the geographic coordinate system for this site. Similar to acquire coordinate system from a link in the UI.

## Syntax (C#)
```csharp
public void SetGeoCoordinateSystem(
	string coordSystem
)
```

## Parameters
- **coordSystem** (`System.String`) - The coordinate system to set for the project.

## Remarks
The ID, WKT or Autodesk coordinate system xml representation of the coordinate reference system definition.
 The xml representation is the same format get via RealDWG's API - AcDbGeoData::coordinateSystem.
 Optionally, the string can be prefixed by the ID's namespace and a colon (:) where the following are supported: ADSK, EPSG.
 If no namespace has been specified, the ID is assumed to be a default Autodesk coordinate system identifier.
 If no definition exists with such a code and if it consists of numbers only, the ID string is considered an EPSG code.
Valid examples are:
 LL84 > Autodesk identifier (default) ADSK:LL84 > Autodesk identifier EPSG:4326 > EPSG identifier 4326 > EPSG identifier GEOGCS["WGS 84", DATUM["WGS_1984", SPHEROID[...]]] > WKT

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - coordSystem is an empty string or contains only whitespace.
 -or-
 The coordinate system is not valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InternalException** - Fail to update coordinate system.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The site location does not come from the project.

