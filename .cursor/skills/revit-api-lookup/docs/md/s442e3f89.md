---
kind: method
id: M:Autodesk.Revit.DB.LabelUtils.GetLabelFor(Autodesk.Revit.DB.Plumbing.PipeLossMethodType,Autodesk.Revit.DB.Document)
source: html/fa0a0158-ecdc-0557-4214-14d5917d8c67.htm
---
# Autodesk.Revit.DB.LabelUtils.GetLabelFor Method

Gets the user-visible name for a PipeLossMethodType.

## Syntax (C#)
```csharp
public static string GetLabelFor(
	PipeLossMethodType pipeLossMethodType,
	Document doc
)
```

## Parameters
- **pipeLossMethodType** (`Autodesk.Revit.DB.Plumbing.PipeLossMethodType`) - The PipeLossMethodType to get the user-visible name.
- **doc** (`Autodesk.Revit.DB.Document`) - The document from which to get the PipeLossMethodType.

## Remarks
The name is obtained in the current Revit language.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when information for the input PipeLossMethodType cannot be found.

