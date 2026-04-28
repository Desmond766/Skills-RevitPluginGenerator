---
kind: method
id: M:Autodesk.Revit.DB.IFC.ImporterIFC.HybridElementImport(Autodesk.Revit.DB.Document,System.String)
source: html/52b91816-fbd5-a28f-d584-3087c4d08cb7.htm
---
# Autodesk.Revit.DB.IFC.ImporterIFC.HybridElementImport Method

Imports IFC Elements using non-open-source framework.

## Syntax (C#)
```csharp
public IList<ElementId> HybridElementImport(
	Document doc,
	string file
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - Document into which Import is done.
- **file** (`System.String`) - Full path of the file to import.

## Returns
Elements imported using non-open-source framework.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

