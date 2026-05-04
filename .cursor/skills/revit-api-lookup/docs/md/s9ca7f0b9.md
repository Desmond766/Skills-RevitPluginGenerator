---
kind: property
id: P:Autodesk.Revit.DB.BaseExportOptions.LayerMapping
source: html/693ca2ec-97d0-a0b4-e5f1-0691b226cfc5.htm
---
# Autodesk.Revit.DB.BaseExportOptions.LayerMapping Property

Name of a layer settings standard or filename (with custom layer settings).
 Valid standards are: DGNV7 (only for DGN), AIA, CP83, BS1192, and ISO13567.
 default value is "" (empty) which means if no value is set,
 if no value is set, Revit will use a default value according to the localization.

## Syntax (C#)
```csharp
public string LayerMapping { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

