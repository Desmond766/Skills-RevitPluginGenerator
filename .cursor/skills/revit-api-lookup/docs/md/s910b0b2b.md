---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.VersionName
source: html/0cda1cfa-dc5c-4209-f931-926bad6153c1.htm
---
# Autodesk.Revit.ApplicationServices.Application.VersionName Property

Returns the name of the Revit application.

## Syntax (C#)
```csharp
public string VersionName { get; }
```

## Remarks
This property can be used by your application to find the version of Revit
against which your application is running. Based on this information your application
can report if it is able to work correctly with that version of Revit.

