---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.VersionBuild
source: html/04ef312a-e25a-cbcd-40c4-43fe6311e677.htm
---
# Autodesk.Revit.ApplicationServices.Application.VersionBuild Property

Returns the internal build number of the Autodesk Revit application.

## Syntax (C#)
```csharp
public string VersionBuild { get; }
```

## Remarks
This property can be used by your application to find the version of Autodesk Revit
against which your application is running. Based on this information your application
can report if it is able to work correctly with that version of Autodesk Revit.

