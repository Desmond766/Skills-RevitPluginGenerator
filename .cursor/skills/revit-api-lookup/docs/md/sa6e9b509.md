---
kind: property
id: P:Autodesk.Revit.ApplicationServices.ControlledApplication.VersionNumber
source: html/35b18b73-4c47-fee3-d2f9-21298f029f7f.htm
---
# Autodesk.Revit.ApplicationServices.ControlledApplication.VersionNumber Property

Return the primary version of the Revit application.

## Syntax (C#)
```csharp
public string VersionNumber { get; }
```

## Remarks
This property can be used by your application to find the version of Revit
against which your application is running. Based on this information your application
can report if it is able to work correctly with that version of Revit.

