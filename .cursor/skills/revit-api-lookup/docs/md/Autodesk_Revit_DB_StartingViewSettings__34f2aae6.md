---
kind: type
id: T:Autodesk.Revit.DB.StartingViewSettings
source: html/aaa6f49c-faeb-851e-45e9-d3d5799c1753.htm
---
# Autodesk.Revit.DB.StartingViewSettings

The initial view settings for a document dictate which view will initially be open when this model
 is opened. These settings are available for all Revit project documents.

## Syntax (C#)
```csharp
public class StartingViewSettings : Element
```

## Remarks
If worksharing is enabled, the same settings will be used by the central model and all
 local files and the settings will live in the Project Info workset.

