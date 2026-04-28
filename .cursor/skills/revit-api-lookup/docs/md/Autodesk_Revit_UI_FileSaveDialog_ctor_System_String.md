---
kind: method
id: M:Autodesk.Revit.UI.FileSaveDialog.#ctor(System.String)
source: html/7f25e970-cc7b-6e65-e0c9-18c67344f32c.htm
---
# Autodesk.Revit.UI.FileSaveDialog.#ctor Method

Constructs a new instance of a File Save dialog.

## Syntax (C#)
```csharp
public FileSaveDialog(
	string filter
)
```

## Parameters
- **filter** (`System.String`) - The filter string. See the remarks for Filter for details.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input filter string does not meet the minimal requirements for a valid filter string.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

