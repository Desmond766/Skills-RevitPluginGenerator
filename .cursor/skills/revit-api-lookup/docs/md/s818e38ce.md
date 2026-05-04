---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceServerUtils.ServerSupportsCADLinks(Autodesk.Revit.DB.ExternalResourceReference)
source: html/66d581a3-9a20-d3ba-47a3-6d17e52fda56.htm
---
# Autodesk.Revit.DB.ExternalResourceServerUtils.ServerSupportsCADLinks Method

Checks that the server referenced by the given ExternalResourceReference supports
 CAD links.

## Syntax (C#)
```csharp
public static bool ServerSupportsCADLinks(
	ExternalResourceReference extRef
)
```

## Parameters
- **extRef** (`Autodesk.Revit.DB.ExternalResourceReference`) - The ExternalResourceReference to check.

## Returns
True if the ExternalResourceReference refers to a server that supports CAD links. False otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

