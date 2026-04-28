---
kind: property
id: P:Autodesk.Revit.ApplicationServices.ControlledApplication.VersionBuild
source: html/c5963cab-c85b-561b-1ea2-b9d11b58050c.htm
---
# Autodesk.Revit.ApplicationServices.ControlledApplication.VersionBuild Property

Returns the internal build number of the Autodesk Revit application.

## Syntax (C#)
```csharp
public string VersionBuild { get; }
```

## Remarks
This property can be used by your application to find the version of Autodesk Revit
against which your application is running. Based on this information your application
can report if it is able to work correctly with that version of Autodesk Revit.

