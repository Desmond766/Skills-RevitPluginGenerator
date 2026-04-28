---
kind: method
id: M:Autodesk.Revit.DB.ExternalGeometryId.#ctor(System.String)
source: html/6a3b9aca-496b-bba1-782c-72388c16579e.htm
---
# Autodesk.Revit.DB.ExternalGeometryId.#ctor Method

Constructs an ExternalGeometryId object holding the given external geometry identifier.

## Syntax (C#)
```csharp
public ExternalGeometryId(
	string externalGeometryId
)
```

## Parameters
- **externalGeometryId** (`System.String`) - A string that represents an identifier for an external geometry.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - externalGeometryId is not a valid ExternalGeometryId.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

