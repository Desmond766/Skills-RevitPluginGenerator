---
kind: method
id: M:Autodesk.Revit.DB.IExternalResourceServer.SupportsExternalResourceType(Autodesk.Revit.DB.ExternalResourceType)
source: html/c9aae122-a3bd-9e30-f440-40694875d9c0.htm
---
# Autodesk.Revit.DB.IExternalResourceServer.SupportsExternalResourceType Method

Implement this method to indicate whether the server can provide data for a specified type of external resource.

## Syntax (C#)
```csharp
bool SupportsExternalResourceType(
	ExternalResourceType type
)
```

## Parameters
- **type** (`Autodesk.Revit.DB.ExternalResourceType`) - The ExternalResourceType of interest to the caller. For example, KeynoteTable - to determine
 if the server provides data for Revit's keynote table.

## Returns
True if the server supports the specified type of external resource

