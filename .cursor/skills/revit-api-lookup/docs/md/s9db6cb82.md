---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceServiceUtils.GetServersByType(Autodesk.Revit.DB.ExternalResourceType)
source: html/0d22fb7a-13f6-7e8f-ae5c-41a646366de3.htm
---
# Autodesk.Revit.DB.ExternalResourceServiceUtils.GetServersByType Method

Gets registered external resource servers which support the external resource type.

## Syntax (C#)
```csharp
public static IList<IExternalResourceServer> GetServersByType(
	ExternalResourceType type
)
```

## Parameters
- **type** (`Autodesk.Revit.DB.ExternalResourceType`) - The external resource type for the servers to match

## Returns
A list of matched external resource servers

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

