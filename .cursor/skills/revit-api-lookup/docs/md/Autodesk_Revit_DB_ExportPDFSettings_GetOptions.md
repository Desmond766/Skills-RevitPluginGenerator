---
kind: method
id: M:Autodesk.Revit.DB.ExportPDFSettings.GetOptions
source: html/f5d51aa8-71ae-0526-1668-e0d97eb8315e.htm
---
# Autodesk.Revit.DB.ExportPDFSettings.GetOptions Method

Gets a copy of options from settings for exporting.
 Modification on this options would not change the element.

## Syntax (C#)
```csharp
public PDFExportOptions GetOptions()
```

## Returns
The options.

## Remarks
Since the [!:PDFExportOptions.FileName] is not serialized, when [!:Combine] 
 is True true true ( True in Visual Basic) (which means all the views would be exported into one PDF file, whose
 file name is specified by [!:PDFExportOptions.FileName] ), the returned PDFExportOptions 
 would have [!:PDFExportOptions.FileName] as an empty string. The user has to
 set the [!:PDFExportOptions.FileName] before calling the [!:Document.Export(string, IList{ElementId}, PDFExportOption)] 
 API exporting a "combined" PDF file.

