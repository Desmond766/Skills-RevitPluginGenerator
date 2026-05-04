---
kind: method
id: M:Autodesk.Revit.UI.FilterDialog.#ctor(Autodesk.Revit.DB.Document,System.String)
source: html/06d66f18-1b9f-8678-d7ef-e7c0441c7c39.htm
---
# Autodesk.Revit.UI.FilterDialog.#ctor Method

Constructs a new instance of the FilterDialog class,
 while setting the name of the new ParameterFilterElement to be created and selected for editing.

## Syntax (C#)
```csharp
public FilterDialog(
	Document doc,
	string name
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document that owns the FilterElements displayed and edited in the dialog.
- **name** (`System.String`) - The user-visible name for the new ParameterFilterElement.

## Remarks
Show the dialog with the Show() method after setting the desired options.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name is an empty string.
 -or-
 name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 The given value for name is already in use as a filter element name.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

