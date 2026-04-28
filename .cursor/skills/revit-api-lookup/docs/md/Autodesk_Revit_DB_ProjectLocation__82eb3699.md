---
kind: type
id: T:Autodesk.Revit.DB.ProjectLocation
source: html/1249d5fa-74f3-cf64-0a63-7ab370b67a5c.htm
---
# Autodesk.Revit.DB.ProjectLocation

A representation of a specific instance and location of the current project.

## Syntax (C#)
```csharp
public class ProjectLocation : Instance
```

## Remarks
When using shared coordinates, ProjectLocations can be used to specify
 specific locations for instances of a linked model. A ProjectLocation
 keeps track of the position of an instance in relationship to the project's
 SiteLocation. By default, each Revit project contains at least one named location, called Internal.
 Existing ProjectLocation objects can be found by using the ProjectLocations property on
 the Document object. New project locations can be created by duplicating an existing project
 location using the Duplicate method, and modifying the location's project position. 
 See also SiteLocation

