---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceServerUtils.ServerSupportsRevitLinks(Autodesk.Revit.DB.ExternalResourceReference)
source: html/154a8896-8d7c-ef67-3168-b91af2df0bcc.htm
---
# Autodesk.Revit.DB.ExternalResourceServerUtils.ServerSupportsRevitLinks Method

Checks that the server referenced by the given ExternalResourceReference supports
 Revit links.

## Syntax (C#)
```csharp
public static bool ServerSupportsRevitLinks(
	ExternalResourceReference extRef
)
```

## Parameters
- **extRef** (`Autodesk.Revit.DB.ExternalResourceReference`) - The ExternalResourceReference to check.

## Returns
True if the ExternalResourceReference refers to a server that supports Revit links. False otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

