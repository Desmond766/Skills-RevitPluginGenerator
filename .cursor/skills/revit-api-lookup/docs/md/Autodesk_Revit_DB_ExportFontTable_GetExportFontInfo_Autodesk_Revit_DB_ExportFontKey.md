---
kind: method
id: M:Autodesk.Revit.DB.ExportFontTable.GetExportFontInfo(Autodesk.Revit.DB.ExportFontKey)
source: html/fd36a0ee-28b7-9521-c90d-3b27f8e0bec0.htm
---
# Autodesk.Revit.DB.ExportFontTable.GetExportFontInfo Method

Gets a copy of the font info associated to the input font key.

## Syntax (C#)
```csharp
public ExportFontInfo GetExportFontInfo(
	ExportFontKey exportFontKey
)
```

## Parameters
- **exportFontKey** (`Autodesk.Revit.DB.ExportFontKey`) - The export font Key.

## Returns
Returns the fontInfo for this key.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - An entry with the given key is not present in the table.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

