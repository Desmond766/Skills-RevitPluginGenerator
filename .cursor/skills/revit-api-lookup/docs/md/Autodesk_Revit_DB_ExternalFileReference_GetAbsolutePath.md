---
kind: method
id: M:Autodesk.Revit.DB.ExternalFileReference.GetAbsolutePath
source: html/4aa39d4e-9d44-6271-aa9c-71b6ab7515ae.htm
---
# Autodesk.Revit.DB.ExternalFileReference.GetAbsolutePath Method

Returns an absolute path to the referenced file,
 regardless of whether the PathType.Enum is relative or absolute.

## Syntax (C#)
```csharp
public ModelPath GetAbsolutePath()
```

## Returns
A full path to the linked model.

## Remarks
ExternalFileReferences which are taken from a closed document will
 report their absolute path as of the last time the document was saved.

