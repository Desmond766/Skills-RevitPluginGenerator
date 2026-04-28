---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ConduitSizeSettings.CreateConduitStandardTypeFromExisingStandardType(Autodesk.Revit.DB.Document,System.String,System.String)
source: html/140bee14-3c01-d17a-5017-2f4301524c04.htm
---
# Autodesk.Revit.DB.Electrical.ConduitSizeSettings.CreateConduitStandardTypeFromExisingStandardType Method

Creates one conduit standard type with the new name and assign the conduit sizes to it from the existing standard type.

## Syntax (C#)
```csharp
public bool CreateConduitStandardTypeFromExisingStandardType(
	Document pADoc,
	string newStandardName,
	string existingStandardName
)
```

## Parameters
- **pADoc** (`Autodesk.Revit.DB.Document`) - The document.
- **newStandardName** (`System.String`) - The new conduit standard name.
- **existingStandardName** (`System.String`) - The existing conduit standard name.

## Returns
True if creating success; otherwise false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The conduit standard name already exists.
 -or-
 The conduit standard name does not exist.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

