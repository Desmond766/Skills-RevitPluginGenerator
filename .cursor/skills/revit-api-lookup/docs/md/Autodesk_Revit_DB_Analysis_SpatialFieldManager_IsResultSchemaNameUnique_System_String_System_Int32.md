---
kind: method
id: M:Autodesk.Revit.DB.Analysis.SpatialFieldManager.IsResultSchemaNameUnique(System.String,System.Int32)
source: html/c25f6957-e7d4-12bd-52e8-a9d9e1250bd6.htm
---
# Autodesk.Revit.DB.Analysis.SpatialFieldManager.IsResultSchemaNameUnique Method

Verify the uniqueness of the name among all registered result schemas.

## Syntax (C#)
```csharp
public bool IsResultSchemaNameUnique(
	string name,
	int resultIndexToSkip
)
```

## Parameters
- **name** (`System.String`) - Name to verify uniqueness of.
- **resultIndexToSkip** (`System.Int32`) - Index of result (e.g. to be replaced) which names should not count for uniqueness; negative number means nothing is excluded from comparison.

## Returns
True if name is unique, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

