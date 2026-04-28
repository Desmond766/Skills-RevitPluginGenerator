---
kind: method
id: M:Autodesk.Revit.DB.ExportFontTable.Add(Autodesk.Revit.DB.ExportFontKey,Autodesk.Revit.DB.ExportFontInfo)
source: html/b60b8eea-4b07-f39a-53c5-6bdb8491df02.htm
---
# Autodesk.Revit.DB.ExportFontTable.Add Method

Inserts a (key,info) pair into Export font table.

## Syntax (C#)
```csharp
public void Add(
	ExportFontKey exportFontKey,
	ExportFontInfo exportFontInfo
)
```

## Parameters
- **exportFontKey** (`Autodesk.Revit.DB.ExportFontKey`) - The export font key to be added.
- **exportFontInfo** (`Autodesk.Revit.DB.ExportFontInfo`) - The export font info to be added.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The key already exists in the table.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

