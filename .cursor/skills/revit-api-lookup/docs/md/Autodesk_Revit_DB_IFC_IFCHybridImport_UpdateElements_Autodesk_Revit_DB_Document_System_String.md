---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCHybridImport.UpdateElements(Autodesk.Revit.DB.Document,System.String)
source: html/c92a4f1c-c644-bcd3-97fc-338fac6a2464.htm
---
# Autodesk.Revit.DB.IFC.IFCHybridImport.UpdateElements Method

Updates IFC Elements using AnyCAD.

## Syntax (C#)
```csharp
public IList<ElementId> UpdateElements(
	Document doc,
	string file
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - Document to receive elements from the IFC file update.
- **file** (`System.String`) - Full path of the file to import.

## Returns
Returns an array of ElementIds representing created or updated elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

