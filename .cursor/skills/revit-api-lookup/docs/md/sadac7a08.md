---
kind: property
id: P:Autodesk.Revit.DB.STLExportOptions.ExportColor
source: html/957ac4e0-9f3c-318b-a036-525fbae1fe7e.htm
---
# Autodesk.Revit.DB.STLExportOptions.ExportColor Property

True to export color information, false otherwise.
 Default value is false.

## Syntax (C#)
```csharp
public bool ExportColor { get; set; }
```

## Remarks
Color information can be exported only in binary STL format, in the case of ASCII STL format this property will be ignored.

