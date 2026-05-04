---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceServerUtils.ServerSupportsKeynotes(Autodesk.Revit.DB.ExternalResourceReference)
source: html/ef3003e0-6e4e-5b6f-1b66-0af06f90b89a.htm
---
# Autodesk.Revit.DB.ExternalResourceServerUtils.ServerSupportsKeynotes Method

Checks that the server referenced by the given ExternalResourceReference supports
 KeynoteTable data.

## Syntax (C#)
```csharp
public static bool ServerSupportsKeynotes(
	ExternalResourceReference extRef
)
```

## Parameters
- **extRef** (`Autodesk.Revit.DB.ExternalResourceReference`) - The ExternalResourceReference to check.

## Returns
True if the ExternalResourceReference refers to a server that supports keynotes. False otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

