---
kind: method
id: M:Autodesk.Revit.DB.ExportDWGSettings.ListNames(Autodesk.Revit.DB.Document)
source: html/03a2609a-7777-f049-5013-c90eaa7054a2.htm
---
# Autodesk.Revit.DB.ExportDWGSettings.ListNames Method

Returns a list of names of dwg/dxf export settings.

## Syntax (C#)
```csharp
public static IList<string> ListNames(
	Document aDoc
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - A Revit document to retrieve names from.

## Returns
An array of strings representing names of predefined setups.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

