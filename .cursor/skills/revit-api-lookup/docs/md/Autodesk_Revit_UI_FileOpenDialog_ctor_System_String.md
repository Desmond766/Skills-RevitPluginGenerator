---
kind: method
id: M:Autodesk.Revit.UI.FileOpenDialog.#ctor(System.String)
source: html/8a2b242c-c597-6e82-15b0-50b6dcd51f00.htm
---
# Autodesk.Revit.UI.FileOpenDialog.#ctor Method

Constructs a new instance of a File Open dialog.

## Syntax (C#)
```csharp
public FileOpenDialog(
	string filter
)
```

## Parameters
- **filter** (`System.String`) - The filter string. See the remarks for Filter for details.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input filter string does not meet the minimal requirements for a valid filter string.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

