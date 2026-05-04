---
kind: method
id: M:Autodesk.Revit.DB.CADLinkType.Reload
source: html/1c168cc0-8569-05e8-dc6f-ff19edf9cb3d.htm
---
# Autodesk.Revit.DB.CADLinkType.Reload Method

Loads or reloads the link from its currently-stored location. If the link is an
 external resource, Revit will contact the IExternalResourceServer to get the latest version
 of the link.

## Syntax (C#)
```csharp
public LinkLoadResult Reload()
```

## Returns
An object containing the ElementId of the link
 and an enum value indicating any
 errors which occurred while trying to load.

## Remarks
If the link is currently loaded, any changes made in-memory
 to the link's shared coordinates will be discarded. Graphic overrides will be preserved on reload. If the original view used to bring in this link has
 been deleted, Revit will cancel the load.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This CADLinkType represents an import and cannot be used as a link.
 -or-
 The element "this CADLinkType" is in a read-only document.

