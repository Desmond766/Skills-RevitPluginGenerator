---
kind: method
id: M:Autodesk.Revit.DB.ExternalFileReference.IsValidPathTypeForExternalFileReference(Autodesk.Revit.DB.PathType)
source: html/25d319de-95af-3790-83fc-576bf5973938.htm
---
# Autodesk.Revit.DB.ExternalFileReference.IsValidPathTypeForExternalFileReference Method

Checks whether a PathType enum value will be valid to
 use with this ExternalFileReference.

## Syntax (C#)
```csharp
public bool IsValidPathTypeForExternalFileReference(
	PathType pathType
)
```

## Parameters
- **pathType** (`Autodesk.Revit.DB.PathType`)

## Remarks
PathType.Server is only valid for ExternalFileReferences of type ExternalFileReferenceType.RevitLink PathType.Content is only valid for ExternalFileReferences of type ExternalFileReferenceType.KeynoteTable,
 ExternalFileReferenceType.AssemblyCodeTable and ExternalFileReferenceType.Decal

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

