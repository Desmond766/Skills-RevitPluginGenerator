---
kind: method
id: M:Autodesk.Revit.ApplicationServices.Application.OpenDocumentFile(System.String)
source: html/14826965-b83e-110c-1466-cc7667def9c8.htm
---
# Autodesk.Revit.ApplicationServices.Application.OpenDocumentFile Method

Opens a document from disk.

## Syntax (C#)
```csharp
public Document OpenDocumentFile(
	string fileName
)
```

## Parameters
- **fileName** (`System.String`) - The file to be opened.

## Returns
The opened document.

## Remarks
This method opens the document into memory but does not make it visible to the user in any way.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The fileName to be opened is empty.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.CannotOpenBothCentralAndLocalException** - Cannot open the local model and the central model in the same Revit session. You can close one to open the other in the same Revit session.
- **Autodesk.Revit.Exceptions.CentralModelException** - Revit encountered serious errors while trying to open the central model.
- **Autodesk.Revit.Exceptions.CorruptModelException** - There are too many corrupt elements to open this model.
- **Autodesk.Revit.Exceptions.FileAccessException** - File cannot be opened in Revit LT because it was last saved in a version of Revit prior to 8.1.
 -or-
 File has an invalid extension. Try changing the file's extension and opening it again.
- **Autodesk.Revit.Exceptions.FileNotFoundException** - The fileName to be opened doesn't exist.
 -or-
 File Not Found
- **Autodesk.Revit.Exceptions.InsufficientResourcesException** - This computer does not have enough memory, disk space, or other necessary resource to open the model.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Open is temporarily disabled.
 -or-
 The document can not be opened.
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Opening was canceled by the user or by an API event callback.

