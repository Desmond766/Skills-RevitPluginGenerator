---
kind: method
id: M:Autodesk.Revit.DB.ImageType.ReloadFrom(Autodesk.Revit.DB.ImageTypeOptions)
source: html/e009ad38-c172-fdf4-56b8-c3be5940cc05.htm
---
# Autodesk.Revit.DB.ImageType.ReloadFrom Method

Reloads the image in the ImageType from a new image file, and for a new PageNumber .

## Syntax (C#)
```csharp
public void ReloadFrom(
	ImageTypeOptions options
)
```

## Parameters
- **options** (`Autodesk.Revit.DB.ImageTypeOptions`) - Options that specify what image to load.

## Remarks
If reload fails (because the image file doesn't exist, cannot be read, or does not have the requested page number),
 the currently loaded image will remain unchanged.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - options.Path is an empty string.
 -or-
 The file represented by options.Path is not a supported image file type.
 -or-
 The image file represented by options.Path is a password protected PDF file.
 -or-
 The image file represented by options.Path does not contain the page specified by options.PageNumber.
 -or-
 The image file represented by options.Path could not be read and may be corrupt.
 -or-
 An error occurred while handling the external resource corresponding to the image.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - The file represented by options.Path does not exist.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This ImageType was not loaded from a file.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document containing this ImageType is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document containing this ImageType is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document containing this ImageType has no open transaction.

