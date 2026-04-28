---
kind: property
id: P:Autodesk.Revit.UI.FileDialog.DefaultFilterEntry
source: html/2753707b-e514-e22b-875c-d38301468f50.htm
---
# Autodesk.Revit.UI.FileDialog.DefaultFilterEntry Property

The default entry (from the filter) to be selected in the dialog.

## Syntax (C#)
```csharp
public string DefaultFilterEntry { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: defaultFilterEntry cannot include prohibited unprintable characters.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

