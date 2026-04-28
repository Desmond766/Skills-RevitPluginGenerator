---
kind: method
id: M:Autodesk.Revit.DB.ExportPDFSettings.IsValidName(Autodesk.Revit.DB.Document,System.String)
source: html/854b7152-17e2-8bc4-2fb4-2fd2f571812e.htm
---
# Autodesk.Revit.DB.ExportPDFSettings.IsValidName Method

Returns result that the proposed name is valid and not exist in the specified document.

## Syntax (C#)
```csharp
public static bool IsValidName(
	Document document,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document to check
- **name** (`System.String`) - Name to check.

## Returns
Whether or not the name is valid.

## Remarks
Name can't contains following characters, such as { } [ ] | ; < > ? ` ~ \ : \r \n \f \t \v.
 Name can't be blank.
 If true, the name is valid and not exist in specified document.
 If false, the name is not a valid name which means it does not exist in specified document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

