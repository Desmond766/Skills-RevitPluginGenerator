---
kind: method
id: M:Autodesk.Revit.DB.ImageType.Unload
source: html/386b1797-4550-8e3d-d67e-0ac45e2091b0.htm
---
# Autodesk.Revit.DB.ImageType.Unload Method

Unload the linked image.

## Syntax (C#)
```csharp
public void Unload()
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This ImageType is not a link.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document containing this ImageType is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document containing this ImageType is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document containing this ImageType has no open transaction.

