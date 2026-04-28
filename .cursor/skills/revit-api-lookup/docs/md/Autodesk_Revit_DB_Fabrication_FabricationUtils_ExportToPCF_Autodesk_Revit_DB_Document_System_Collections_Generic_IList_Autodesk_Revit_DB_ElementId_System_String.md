---
kind: method
id: M:Autodesk.Revit.DB.Fabrication.FabricationUtils.ExportToPCF(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.ElementId},System.String)
source: html/99c52e0d-4cac-c753-ff9b-35554f6454fd.htm
---
# Autodesk.Revit.DB.Fabrication.FabricationUtils.ExportToPCF Method

Exports a list of fabrication parts into PCF format.

## Syntax (C#)
```csharp
public static void ExportToPCF(
	Document document,
	IList<ElementId> ids,
	string filename
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **ids** (`System.Collections.Generic.IList < ElementId >`) - An array of FabricationPart element identifiers. Non-fabrication parts are ignored.
- **filename** (`System.String`) - The name given to the output file.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Fabrication configuration is missing.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

