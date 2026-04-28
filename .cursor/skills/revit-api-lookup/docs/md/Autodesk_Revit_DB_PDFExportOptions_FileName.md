---
kind: property
id: P:Autodesk.Revit.DB.PDFExportOptions.FileName
source: html/26f04248-487f-bb5a-d04a-95c7b63a4394.htm
---
# Autodesk.Revit.DB.PDFExportOptions.FileName Property

File name of the PDF when Combine is True true true ( True in Visual Basic) .

## Syntax (C#)
```csharp
public string FileName { get; set; }
```

## Remarks
PDF file extension (".pdf") would be automatically appended to the result file.
 When Combine is False false false ( False in Visual Basic) , this would be ignored.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

