---
kind: method
id: M:Autodesk.Revit.DB.ExternalFileReference.IsValidExternalFileReference(Autodesk.Revit.DB.ExternalFileReference)
source: html/69a596e8-72a8-52d6-a807-c443b5891dba.htm
---
# Autodesk.Revit.DB.ExternalFileReference.IsValidExternalFileReference Method

Checks an ExternalFileReference to see if it is
 properly created.

## Syntax (C#)
```csharp
public static bool IsValidExternalFileReference(
	ExternalFileReference data
)
```

## Parameters
- **data** (`Autodesk.Revit.DB.ExternalFileReference`) - The ExternalFileReference to be checked

## Remarks
The following restrictions exist:
 PathType.Server is only valid for ExternalFileReferences of type ExternalFileReferenceType.RevitLink PathType.Content is only valid for ExternalFileReferences of type ExternalFileReferenceType.KeynoteTable,
 ExternalFileReferenceType.AssemblyCodeTable or ExternalFileReferenceType.Decal Keynote tables, assembly code tables and Decals (ExternalFileReferenceType.KeynoteTable,
 ExternalFileReferenceType.AssemblyCodeTable and ExternalFileReferenceType.Decal) may only be
 LinkedFileStatus.Loaded or LinkedFileStatus.NotFound.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

