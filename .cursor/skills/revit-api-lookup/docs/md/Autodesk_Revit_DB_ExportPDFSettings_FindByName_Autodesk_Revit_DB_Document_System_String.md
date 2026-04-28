---
kind: method
id: M:Autodesk.Revit.DB.ExportPDFSettings.FindByName(Autodesk.Revit.DB.Document,System.String)
source: html/c7b081d1-a996-7a34-2486-a80af67977ba.htm
---
# Autodesk.Revit.DB.ExportPDFSettings.FindByName Method

Returns settings element by name.

## Syntax (C#)
```csharp
public static ExportPDFSettings FindByName(
	Document document,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to find the settings with the specified name.
- **name** (`System.String`) - Name of the settings to find.

## Returns
The settings element, or Nothing nullptr a null reference ( Nothing in Visual Basic) if not found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

