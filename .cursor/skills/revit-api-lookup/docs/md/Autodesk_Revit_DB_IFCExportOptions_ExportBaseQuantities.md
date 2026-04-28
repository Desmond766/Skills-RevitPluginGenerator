---
kind: property
id: P:Autodesk.Revit.DB.IFCExportOptions.ExportBaseQuantities
source: html/209a8948-d2c0-0c4e-d3b7-241535ccbad8.htm
---
# Autodesk.Revit.DB.IFCExportOptions.ExportBaseQuantities Property

Option to export IFC standard quantities currently supported by Revit.

## Syntax (C#)
```csharp
public bool ExportBaseQuantities { get; set; }
```

## Remarks
IFC has created a list of common quantities (e.g. length, area, volume, etc.)
 that can optionally be exported along with the 3D representation for many element
 types (e.g. walls, columns, doors). Setting this option to true will cause the export
 procedure to include the set of IFC quantities that Revit currently supports.
 Default is false.

