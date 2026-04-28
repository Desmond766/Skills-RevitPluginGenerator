---
kind: type
id: T:Autodesk.Revit.DB.WorksetDefaultVisibilitySettings
source: html/8a6f0949-069b-4b83-380c-f6582ef37a40.htm
---
# Autodesk.Revit.DB.WorksetDefaultVisibilitySettings

An object that manages default visibility of worksets in a document.

## Syntax (C#)
```csharp
public class WorksetDefaultVisibilitySettings : Element
```

## Remarks
WorksetDefaultVisibilitySettings does not exist for family documents.
 In case worksharing is disabled in a document, all elements are moved into a single workset;
 that workset, and any worksets (re)created if worksharing is re-enabled, is visible by default regardless of any current settings.

