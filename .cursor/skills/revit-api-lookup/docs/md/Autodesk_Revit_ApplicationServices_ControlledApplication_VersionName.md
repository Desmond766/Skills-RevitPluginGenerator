---
kind: property
id: P:Autodesk.Revit.ApplicationServices.ControlledApplication.VersionName
source: html/922cc2ba-ada9-9087-fc37-de8704e81218.htm
---
# Autodesk.Revit.ApplicationServices.ControlledApplication.VersionName Property

Returns the name of the Revit application.

## Syntax (C#)
```csharp
public string VersionName { get; }
```

## Remarks
This property can be used by your application to find the version of Revit
against which your application is running. Based on this information your application
can report if it is able to work correctly with that version of Revit.

