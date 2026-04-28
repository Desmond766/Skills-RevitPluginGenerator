---
kind: method
id: M:Autodesk.Revit.DB.CADLinkType.Reload(Autodesk.Revit.DB.CADLinkOptions)
source: html/af726997-dc33-890b-ebcf-f5edd7e4eb79.htm
---
# Autodesk.Revit.DB.CADLinkType.Reload Method

Loads or reloads the link from its currently-stored location. If the link is an
 external resource, Revit will contact the IExternalResourceServer to get the latest version
 of the link.

## Syntax (C#)
```csharp
public LinkLoadResult Reload(
	CADLinkOptions options
)
```

## Parameters
- **options** (`Autodesk.Revit.DB.CADLinkOptions`) - Options for reloading the link. Options include
 the ability to preserve graphic overrides on reload.

## Returns
An object containing the ElementId of the link
 and an enum value indicating any
 errors which occurred while trying to load.

## Remarks
If the link is currently loaded, any changes made in-memory
 to the link's shared coordinates will be discarded.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This CADLinkType represents an import and cannot be used as a link.
 -or-
 The element "this CADLinkType" is in a read-only document.

