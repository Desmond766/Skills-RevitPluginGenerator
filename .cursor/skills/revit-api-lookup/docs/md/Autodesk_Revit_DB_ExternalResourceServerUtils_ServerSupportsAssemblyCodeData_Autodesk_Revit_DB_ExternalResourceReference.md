---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceServerUtils.ServerSupportsAssemblyCodeData(Autodesk.Revit.DB.ExternalResourceReference)
source: html/7db6277b-f48f-a7e9-6bd4-2798999cb9df.htm
---
# Autodesk.Revit.DB.ExternalResourceServerUtils.ServerSupportsAssemblyCodeData Method

Checks that the server referenced by the given ExternalResourceReference supports
 AssemblyCodeData.

## Syntax (C#)
```csharp
public static bool ServerSupportsAssemblyCodeData(
	ExternalResourceReference extRef
)
```

## Parameters
- **extRef** (`Autodesk.Revit.DB.ExternalResourceReference`) - The ExternalResourceReference to check.

## Returns
True if the ExternalResourceReference refers to a server that supports AssemblyCodeData. False otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

