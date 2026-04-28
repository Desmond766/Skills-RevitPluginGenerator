---
kind: method
id: M:Autodesk.Revit.DB.LoadedFamilyIntegrityCheck.CheckAllFamilies(Autodesk.Revit.DB.Document,System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId})
source: html/f6f51ffd-ff4b-e960-4749-97ba062e0a49.htm
---
# Autodesk.Revit.DB.LoadedFamilyIntegrityCheck.CheckAllFamilies Method

Check that all families loaded in the host document have their content documents.

## Syntax (C#)
```csharp
public static bool CheckAllFamilies(
	Document ADoc,
	ISet<ElementId> corruptFamilyIds
)
```

## Parameters
- **ADoc** (`Autodesk.Revit.DB.Document`) - The host document.
- **corruptFamilyIds** (`System.Collections.Generic.ISet < ElementId >`) - Return ids of families that need to be reloaded because their content documents are missing.

## Returns
Returns true if all loaded families have their content documents.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

