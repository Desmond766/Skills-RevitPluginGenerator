---
kind: type
id: T:Autodesk.Revit.DB.SiteLocation
source: html/9d71159d-514c-c1b3-8673-5c0e7f28b688.htm
---
# Autodesk.Revit.DB.SiteLocation

Contains the geographical location information for the project's site.

## Syntax (C#)
```csharp
public class SiteLocation : ElementType
```

## Remarks
Each project may have one site which dictates where in the world the project is
 based. On this site there may be several locations of the same project. These are represented
 by ProjectLocation objects. The site location object can be found by using the SiteLocation property
 on the Document object. The properties of this object can be changed such that it represents any
 location on the planet or to a known city. Cities already programmed into Revit can be found
 from the Cities property on the Application object.

