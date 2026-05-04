---
kind: property
id: P:Autodesk.Revit.DB.PDFExportOptions.Combine
source: html/65f97585-8c92-b52e-93dd-8a6b4bfc5a1a.htm
---
# Autodesk.Revit.DB.PDFExportOptions.Combine Property

Whether export all views and sheets into one PDF file or multiple files.

## Syntax (C#)
```csharp
public bool Combine { get; set; }
```

## Remarks
If True true true ( True in Visual Basic) , all exported views and sheets will be exported into one PDF file, whose file name would be specified by FileName .
 If False false false ( False in Visual Basic) , each exported view and sheet will have its own PDF file created, whose file name would be generated with [!:NamingRule] .

