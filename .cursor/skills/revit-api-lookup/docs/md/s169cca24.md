---
kind: property
id: P:Autodesk.Revit.DB.BasicFileInfo.IsSavedInLaterVersion
source: html/27a0583a-c2e4-b198-cf60-168f51c07b13.htm
---
# Autodesk.Revit.DB.BasicFileInfo.IsSavedInLaterVersion Property

Checks if the file is saved in a later version of Revit than the running Revit.

## Syntax (C#)
```csharp
public bool IsSavedInLaterVersion { get; }
```

## Remarks
If the structure of the BasicFileInfo storage has not changed in a newer format file,
 this will indicate that the file format is newer.
 However, if the structure of the storage has changed in a newer format file,
 extraction would have failed and this method cannot be used to make that determination.

