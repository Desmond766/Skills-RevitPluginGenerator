---
kind: method
id: M:Autodesk.Revit.DB.Document.Export(System.String,System.String,Autodesk.Revit.DB.IFCExportOptions)
zh: 导出、输出
source: html/7efa4eb3-8d94-b8e7-f608-3dbae751331d.htm
---
# Autodesk.Revit.DB.Document.Export Method

**中文**: 导出、输出

Exports the document to the Industry Standard Classes (IFC) format.

## Syntax (C#)
```csharp
public bool Export(
	string folder,
	string name,
	IFCExportOptions options
)
```

## Parameters
- **folder** (`System.String`) - Output folder into which the file will be exported. The folder must exist.
- **name** (`System.String`) - Either the name of a single file or a prefix for a set of files.
 If empty, automatic naming will be used.
- **options** (`Autodesk.Revit.DB.IFCExportOptions`) - Various options applicable to the IFC format.
 If Nothing nullptr a null reference ( Nothing in Visual Basic) , all options will be set to their respective default values.

## Returns
True if successful, otherwise False.

## Remarks
Exporting to IFC requires that document is modifiable, therefore there must be a transaction already open when this method is called.
 This method may not be invoked during dynamic update, for the internal routine might need to modify the existing transaction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - NullOrEmpty
 -or-
 Contains invalid characters.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - The IFCExportOptions FamilyMappingFile does not exist.
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - This method may not be called during dynamic update.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Export is temporarily disabled.
 -or-
 Exporting is not allowed in the current application mode.
 -or-
 This Document is not a project document.
- **Autodesk.Revit.Exceptions.InvalidPathArgumentException** - The folder does not exist.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.
- **Autodesk.Revit.Exceptions.OptionalFunctionalityNotAvailableException** - The IFC module is not available in the installed Revit.

