---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetProperty.IsValidSchemaIdentifier(System.String)
source: html/22a7e616-123f-ec35-b162-067dda3a6a60.htm
---
# Autodesk.Revit.DB.Visual.AssetProperty.IsValidSchemaIdentifier Method

Check that schema name is valid

## Syntax (C#)
```csharp
public bool IsValidSchemaIdentifier(
	string schemaID
)
```

## Parameters
- **schemaID** (`System.String`) - The schema name.

## Returns
True if the schema name is valid.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Cannot check validity for a property not being edited in AppearanceAssetEditScope.

