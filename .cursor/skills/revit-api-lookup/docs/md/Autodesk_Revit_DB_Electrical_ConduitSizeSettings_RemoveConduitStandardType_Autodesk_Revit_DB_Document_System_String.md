---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ConduitSizeSettings.RemoveConduitStandardType(Autodesk.Revit.DB.Document,System.String)
source: html/608651d0-d4f2-d85a-5230-672dd360d4e2.htm
---
# Autodesk.Revit.DB.Electrical.ConduitSizeSettings.RemoveConduitStandardType Method

Erases the existing ConduitSizes with this conduit standard name; the consuit standard type can not be removed if it is in use.

## Syntax (C#)
```csharp
public bool RemoveConduitStandardType(
	Document pADoc,
	string standardName
)
```

## Parameters
- **pADoc** (`Autodesk.Revit.DB.Document`) - The document.
- **standardName** (`System.String`) - The conduit standard name.

## Returns
True if removing success; otherwise false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The conduit standard is already in use.
 -or-
 The conduit standard is the last one.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

