---
kind: method
id: M:Autodesk.Revit.DB.Architecture.TopographyLinkType.Reload
source: html/5ef11069-e94e-c1f5-246e-73d43b0cf673.htm
---
# Autodesk.Revit.DB.Architecture.TopographyLinkType.Reload Method

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

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The element "this TopographyLinkType" is in a read-only document.

