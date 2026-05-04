---
kind: type
id: T:Autodesk.Revit.DB.IGetLocalPathForOpenCallback
source: html/05042f18-441f-70ef-51b9-ce84097f6ca1.htm
---
# Autodesk.Revit.DB.IGetLocalPathForOpenCallback

The interface used to provide custom support for the "Open (and Unload)" command for Revit Links obtained as external resources.

## Syntax (C#)
```csharp
public interface IGetLocalPathForOpenCallback
```

## Remarks
Revit documents that are linked into host documents are read-only. If the user wishes to edit a linked Revit file
 they can use the "Open (and Unload)" command to unload the link, and automatically load it directly as a top-level,
 modifiable document (Revit files cannot be edited while they are being used as links). To support this operation for
 Revit links obtained as external resources, IExternalResourceServer authors should implement this callback. They
 should return a local path from where Revit can open the linked document for edit. Ideally, this should be a
 path that is different than the location from where it has been loaded as a link. Once the user opens a link as a top-level document, they will presumably make changes to it and save it. It is
 the responsibility of the server to upload whatever changes the user makes so that the version stored on the server
 remains the most current. Server providers can determine when changes have been made by the user to local file
 by watching for the DocumentSaved event.

