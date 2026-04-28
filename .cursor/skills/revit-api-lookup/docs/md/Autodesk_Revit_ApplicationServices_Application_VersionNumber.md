---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.VersionNumber
source: html/320391bf-2c21-98ca-192c-da1d9becff11.htm
---
# Autodesk.Revit.ApplicationServices.Application.VersionNumber Property

Return the primary version of the Revit application.

## Syntax (C#)
```csharp
public string VersionNumber { get; }
```

## Remarks
This property can be used by your application to find the version of Revit
against which your application is running. Based on this information your application
can report if it is able to work correctly with that version of Revit.

