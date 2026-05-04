---
kind: property
id: P:Autodesk.Revit.DB.IFC.IFCImportOptions.AutocorrectOffAxisLines
source: html/7c134ff4-e2e3-c74e-e828-079963d773a8.htm
---
# Autodesk.Revit.DB.IFC.IFCImportOptions.AutocorrectOffAxisLines Property

Enable or disable correcting lines that are slight off-axis.

## Syntax (C#)
```csharp
public bool AutocorrectOffAxisLines { get; set; }
```

## Remarks
Enabling correcting lines that are slightly off-axis will snap lines that are close to axes
 to the nearest axis. This will reduce warnings in Revit, but may cause elements that are created
 from sketches to slightly change shape, and extrusions to slightly change directions.
 Disabling this option will leave the original geometry intact but may cause warnings in Revit.
 Default is true for Open IFC; it is ignored (and false) for Link IFC.

