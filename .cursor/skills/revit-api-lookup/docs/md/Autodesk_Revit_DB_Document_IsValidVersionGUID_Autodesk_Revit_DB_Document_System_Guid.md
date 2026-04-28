---
kind: method
id: M:Autodesk.Revit.DB.Document.IsValidVersionGUID(Autodesk.Revit.DB.Document,System.Guid)
zh: 文档、文件
source: html/375638e9-fb7c-06c8-11b6-29dfdde4c4a1.htm
---
# Autodesk.Revit.DB.Document.IsValidVersionGUID Method

**中文**: 文档、文件

Checks whether the GUID is valid for the given document. Empty GUID is allowed.

## Syntax (C#)
```csharp
public static bool IsValidVersionGUID(
	Document document,
	Guid versionGUID
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Target document.
- **versionGUID** (`System.Guid`) - The GUID to check.

## Returns
True if the GUID is valid.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

