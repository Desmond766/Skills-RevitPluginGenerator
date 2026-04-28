---
kind: method
id: M:Autodesk.Revit.DB.ImageType.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ImageTypeOptions)
zh: 创建、新建、生成、建立、新增
source: html/31bb13e3-e8f5-cb66-18d0-619578d56cde.htm
---
# Autodesk.Revit.DB.ImageType.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new ImageType element and loads the image into it.

## Syntax (C#)
```csharp
public static ImageType Create(
	Document document,
	ImageTypeOptions options
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **options** (`Autodesk.Revit.DB.ImageTypeOptions`) - Options that specify what image to load.

## Returns
The new ImageType.

## Remarks
The ImageType will be created but will not be placed into any view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The image filename is an empty string.
 -or-
 The image file is not a supported image file type.
 -or-
 The image file is password protected.
 -or-
 The image file does not contain the requested page number.
 -or-
 The image file could not be read and may be corrupt.
 -or-
 An error occurred while handling the external resource corresponding to the image.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - The image file does not exist.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

