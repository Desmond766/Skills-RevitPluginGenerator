---
kind: method
id: M:Autodesk.Revit.DB.CADLinkType.LoadFrom(Autodesk.Revit.DB.ExternalResourceReference)
source: html/de80a921-92a2-ad7e-5aa5-355eb850a992.htm
---
# Autodesk.Revit.DB.CADLinkType.LoadFrom Method

Loads or reloads the DWG link from the given external resource reference.

## Syntax (C#)
```csharp
public LinkLoadResult LoadFrom(
	ExternalResourceReference resourceReference
)
```

## Parameters
- **resourceReference** (`Autodesk.Revit.DB.ExternalResourceReference`) - An ExternalResourceReference giving the location of the
 link. This method can be used to load the link from a
 file on disk. See [!:Autodesk::Revit::DB::ExternalResourceReference::CreateLocalResource()] .

## Returns
An object containing the ElementId of the link
 and an enum value indicating any
 errors which occurred while trying to load.

## Remarks
If the link is currently loaded, any changes made in-memory
 to the link's shared coordinates will be discarded. Graphic overrides will be preserved on reload. If the original view used to bring in this link has
 been deleted, Revit will cancel the load. If there is already another link, not current link itself,
 using the given external resource reference, the loading will not happen.
 The element id of the link using the external resource reference will be contained
 in the LinkLoadResult. This function checks the actual resource path that the IExternalResourceServer returns.
 If the link type identified by the resource path doesn't match DWG, the load will not proceed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The server referenced by the ExternalResourceReference does not exist or
 does not implement IExternalResourceServer.
 -or-
 The server referenced by the ExternalResourceReference cannot support CAD links.
 -or-
 The ExternalResourceReference (resourceReference) is not in a format
 that is supported by its server.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This CADLinkType represents an import and cannot be used as a link.
 -or-
 The element "this CADLinkType" is in a read-only document.
 -or-
 The link does not represent a DWG.

