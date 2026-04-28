---
kind: method
id: M:Autodesk.Revit.DB.ExportLayerKey.#ctor(System.String,System.String,Autodesk.Revit.DB.SpecialType)
source: html/9e7d5343-4822-246e-c751-40267de582c7.htm
---
# Autodesk.Revit.DB.ExportLayerKey.#ctor Method

Constructs a new ExportLayerKey with categoryName, subCategoryName and a special type.

## Syntax (C#)
```csharp
public ExportLayerKey(
	string categoryName,
	string subCategoryName,
	SpecialType num
)
```

## Parameters
- **categoryName** (`System.String`) - The category name for the layer key.
- **subCategoryName** (`System.String`) - The subCategoryName for the layer key.
- **num** (`Autodesk.Revit.DB.SpecialType`) - The special type for layer key.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

