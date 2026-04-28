---
kind: property
id: P:Autodesk.Revit.DB.ExportFontTable.Item(Autodesk.Revit.DB.ExportFontKey)
source: html/ee978923-d6f9-3e7a-98f3-e4f52fae2c94.htm
---
# Autodesk.Revit.DB.ExportFontTable.Item Property

A copy of the ExportFontInfo for the font's ExportFontKey .

## Syntax (C#)
```csharp
public ExportFontInfo this[
	ExportFontKey fontKey
] { get; set; }
```

## Parameters
- **fontKey** (`Autodesk.Revit.DB.ExportFontKey`)

## Returns
A copy of the ExportFontInfo .

## Remarks
When getting this property, it returns a copy of the ExportFontInfo from the table. In order to
 make changes to the ExportFontInfo and use those settings during export, set the modified
 ExportFontInfo back into the table using the same key.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When getting this property:
 An entry with the given key is not present in the table.

