---
kind: method
id: M:Autodesk.Revit.DB.ConnectorManager.Lookup(System.Int32)
source: html/346ec8af-1e85-6b68-6417-29a27a0d0978.htm
---
# Autodesk.Revit.DB.ConnectorManager.Lookup Method

Lookup the connector using the unique index value that identify this connector.

## Syntax (C#)
```csharp
public Connector Lookup(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The unique index value.

## Returns
Returns the connector or null if a connector for the provided unique index value doesn't exist.

