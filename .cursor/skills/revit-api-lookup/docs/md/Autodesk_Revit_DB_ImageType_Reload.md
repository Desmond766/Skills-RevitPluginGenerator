---
kind: method
id: M:Autodesk.Revit.DB.ImageType.Reload
source: html/9d45a435-bf47-e6a7-15b2-7f5584d260ec.htm
---
# Autodesk.Revit.DB.ImageType.Reload Method

Reloads the ImageType from the file found at the location specified by the Path property,
 using the same PageNumber and resolution.

## Syntax (C#)
```csharp
public void Reload()
```

## Remarks
If reload fails (because the image file doesn't exist, cannot be read, or does not have the correct page),
 the currently loaded image will remain unchanged.

## Exceptions
- **Autodesk.Revit.Exceptions.FileNotFoundException** - The file represented by Path does not exist.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This ImageType was not loaded from a file.
 -or-
 The file represented by Path is not a supported image file type.
 -or-
 The image file represented by Path is a password protected PDF file.
 -or-
 The image file represented by Path does not contain the page specified by PageNumber.
 -or-
 The image file represented by Path could not be read and may be corrupt.
 -or-
 An error occurred while handling the external resource corresponding to the image.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document containing this ImageType is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document containing this ImageType is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document containing this ImageType has no open transaction.

