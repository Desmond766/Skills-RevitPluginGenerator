---
kind: method
id: M:Autodesk.Revit.DB.Document.Link(System.String,Autodesk.Revit.DB.DWFImportOptions)
zh: 链接模型、链接
source: html/4d18bcd5-77bb-a1fe-6789-dfcf5afee849.htm
---
# Autodesk.Revit.DB.Document.Link Method

**中文**: 链接模型、链接

Links Markups in a DWF file into the project document.

## Syntax (C#)
```csharp
public IList<ElementId> Link(
	string file,
	DWFImportOptions options
)
```

## Parameters
- **file** (`System.String`) - Full path of the file to link. File must exist and must be a valid DWF file.
- **options** (`Autodesk.Revit.DB.DWFImportOptions`) - Various link options applicable to the DWF format.

## Returns
A collection of link instance element ids created by the markup link.

## Remarks
Link isn't supported for family documents. Please use import instead.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Not a valid file for DWF import (.dwf or.dwfx files are valid).
 -or-
 Some of the views are not importable.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - The given file does not exist.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Import is temporarily disabled.
 -or-
 This Document is not a project document.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

