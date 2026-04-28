---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCHybridImport.ImportElements(Autodesk.Revit.DB.Document,System.String)
source: html/7d0a704f-1f57-ffe4-8853-a2326dfaf88d.htm
---
# Autodesk.Revit.DB.IFC.IFCHybridImport.ImportElements Method

Imports IFC Elements using AnyCAD.

## Syntax (C#)
```csharp
public IList<ElementId> ImportElements(
	Document doc,
	string file
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - Document to receive elements from the IFC file import.
- **file** (`System.String`) - Full path of the file to import.

## Returns
Returns an array of ElementIds representing created elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

