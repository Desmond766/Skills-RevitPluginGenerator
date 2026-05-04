---
kind: method
id: M:Autodesk.Revit.DB.MEPAnalyticalConnectionType.IsNameUnused(Autodesk.Revit.DB.Document,System.String)
source: html/235f1ec6-7058-2592-be87-f434e934e404.htm
---
# Autodesk.Revit.DB.MEPAnalyticalConnectionType.IsNameUnused Method

Checks if this is an unused name.

## Syntax (C#)
```csharp
public static bool IsNameUnused(
	Document doc,
	string name
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document.
- **name** (`System.String`) - The name to be verified.

## Returns
True if not used by an existing analytical connection type in this document, false if used.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

