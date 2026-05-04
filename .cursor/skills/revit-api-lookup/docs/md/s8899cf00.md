---
kind: method
id: M:Autodesk.Revit.DB.CADLinkType.LoadFrom(System.String)
source: html/41db0b8b-4bd4-02b0-f06a-a7a169802e1b.htm
---
# Autodesk.Revit.DB.CADLinkType.LoadFrom Method

Loads or reloads the DWG link from the given file path.

## Syntax (C#)
```csharp
public LinkLoadResult LoadFrom(
	string path
)
```

## Parameters
- **path** (`System.String`) - A path on disk giving the location of the linked file. This path
 must be absolute. The link's path will remain PathType.Absolute
 or PathType.Relative, whichever it was before. If the link was
 previously to an external server location, the path type will be
 relative.

## Returns
An object containing the ElementId of the link
 and an enum value indicating any
 errors which occurred while trying to load.

## Remarks
If the link is currently loaded, any changes made in-memory
 to the link's shared coordinates will be discarded. Graphic overrides will be preserved on reload. If the original view used to bring in this link has
 been deleted, Revit will cancel the load. If there is already another link, not current link itself,
 using the given file path, the loading will not happen.
 The element id of the link using the file path will be contained
 in the LinkLoadResult. If the link type identified by the given path doesn't match DWG,
 the load will not proceed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - The given path does not exist.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This CADLinkType represents an import and cannot be used as a link.
 -or-
 The element "this CADLinkType" is in a read-only document.
 -or-
 The link does not represent a DWG.

