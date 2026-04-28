---
kind: method
id: M:Autodesk.Revit.DB.OptionalFunctionalityUtils.IsNavisworksExporterAvailable
source: html/429a8247-5f73-a254-1377-f384a9360226.htm
---
# Autodesk.Revit.DB.OptionalFunctionalityUtils.IsNavisworksExporterAvailable Method

Checks whether a Navisworks Exporter is available in the installed Revit.

## Syntax (C#)
```csharp
public static bool IsNavisworksExporterAvailable()
```

## Returns
True if a Navisworks Exporter is available in the installed Revit.

## Remarks
A Navisworks exporter is registered via an external add-in. If no add-in has registered an exporter, this will not be a part of the session.

