---
kind: method
id: M:Autodesk.Revit.DB.KeyBasedTreeEntryTable.ServerSupports(Autodesk.Revit.DB.ExternalResourceReference)
source: html/e9a1009d-a56e-d3f6-7987-5b2de9104c93.htm
---
# Autodesk.Revit.DB.KeyBasedTreeEntryTable.ServerSupports Method

Checks if the server referenced by the given ExternalResourceReference supports the
 ExternalResourceReferenceType of this KeyBasedTreeEntryTable.

## Syntax (C#)
```csharp
public bool ServerSupports(
	ExternalResourceReference extRef
)
```

## Parameters
- **extRef** (`Autodesk.Revit.DB.ExternalResourceReference`) - The ExternalResourceReference to check.

## Returns
True if the ExternalResourceReference refers to a server that supports the ExternalResourceReferenceType of this KeyBasedTreeEntryTable.
 False otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

