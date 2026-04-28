---
kind: method
id: M:Autodesk.Revit.DB.ExternalGeometryId.IsValidExternalGeometryId(System.String)
source: html/96e899a0-30cb-1d56-44f0-ad8b24965ba7.htm
---
# Autodesk.Revit.DB.ExternalGeometryId.IsValidExternalGeometryId Method

Checks whether a given string represents a valid ExternalGeometryId or not.

## Syntax (C#)
```csharp
public static bool IsValidExternalGeometryId(
	string externalGeometryId
)
```

## Parameters
- **externalGeometryId** (`System.String`) - A string that represents an identifier for an external geometry.

## Returns
True if the string represents a valid ExternalGeometryId, false otherwise.

## Remarks
Any non-empty string is a valid ExternalGeometryId.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

