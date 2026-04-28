---
kind: method
id: M:Autodesk.Revit.DB.LabelUtils.GetLabelFor(Autodesk.Revit.DB.Mechanical.DuctLossMethodType,Autodesk.Revit.DB.Document)
source: html/42396276-236f-3d66-84af-877397c4b08b.htm
---
# Autodesk.Revit.DB.LabelUtils.GetLabelFor Method

Gets the user-visible name for a DuctLossMethodType.

## Syntax (C#)
```csharp
public static string GetLabelFor(
	DuctLossMethodType ductLossMethodType,
	Document doc
)
```

## Parameters
- **ductLossMethodType** (`Autodesk.Revit.DB.Mechanical.DuctLossMethodType`) - The DuctLossMethodType to get the user-visible name.
- **doc** (`Autodesk.Revit.DB.Document`) - The document from which to get the DuctLossMethodType.

## Remarks
The name is obtained in the current Revit language.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when information for the input DuctLossMethodType cannot be found.

