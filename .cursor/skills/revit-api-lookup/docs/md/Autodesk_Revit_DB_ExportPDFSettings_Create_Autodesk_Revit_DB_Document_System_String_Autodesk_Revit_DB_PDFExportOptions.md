---
kind: method
id: M:Autodesk.Revit.DB.ExportPDFSettings.Create(Autodesk.Revit.DB.Document,System.String,Autodesk.Revit.DB.PDFExportOptions)
zh: 创建、新建、生成、建立、新增
source: html/089c5517-8e5d-7c74-b53b-d59dacb06c5d.htm
---
# Autodesk.Revit.DB.ExportPDFSettings.Create Method

**中文**: 创建、新建、生成、建立、新增

Returns an new created ExportPDFSettings element in the document with specified settings.

## Syntax (C#)
```csharp
public static ExportPDFSettings Create(
	Document document,
	string name,
	PDFExportOptions options
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document where the settings will be created.
- **name** (`System.String`) - Name to the settings.
- **options** (`Autodesk.Revit.DB.PDFExportOptions`) - The options to be set.

## Returns
New instance of ExportPDFSettings just created in the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name is an empty string or contains only whitespace.
 -or-
 name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 Setting name.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

