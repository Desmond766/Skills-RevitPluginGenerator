---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceServerUtils.ServerSupportsIFCLinks(Autodesk.Revit.DB.ExternalResourceReference)
source: html/71ee69fe-7a99-2af7-fb5e-d6e1533ea16e.htm
---
# Autodesk.Revit.DB.ExternalResourceServerUtils.ServerSupportsIFCLinks Method

Checks that the server referenced by the given ExternalResourceReference supports
 IFC links.

## Syntax (C#)
```csharp
public static bool ServerSupportsIFCLinks(
	ExternalResourceReference extRef
)
```

## Parameters
- **extRef** (`Autodesk.Revit.DB.ExternalResourceReference`) - The ExternalResourceReference to check.

## Returns
True if the ExternalResourceReference refers to a server that supports IFC links. False otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

