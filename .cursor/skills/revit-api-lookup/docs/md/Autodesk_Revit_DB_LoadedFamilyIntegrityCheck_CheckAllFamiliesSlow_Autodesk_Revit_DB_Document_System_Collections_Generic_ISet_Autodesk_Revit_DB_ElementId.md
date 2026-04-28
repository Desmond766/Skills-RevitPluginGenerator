---
kind: method
id: M:Autodesk.Revit.DB.LoadedFamilyIntegrityCheck.CheckAllFamiliesSlow(Autodesk.Revit.DB.Document,System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId})
source: html/d34f291d-11b1-7923-85f3-11b7eb9f1bb0.htm
---
# Autodesk.Revit.DB.LoadedFamilyIntegrityCheck.CheckAllFamiliesSlow Method

Check integrity of content documents of all families loaded in the host document.

## Syntax (C#)
```csharp
public static bool CheckAllFamiliesSlow(
	Document ADoc,
	ISet<ElementId> corruptFamilyIds
)
```

## Parameters
- **ADoc** (`Autodesk.Revit.DB.Document`) - The host document.
- **corruptFamilyIds** (`System.Collections.Generic.ISet < ElementId >`) - Return ids of families that need to be reloaded because their content documents are missing or corrupt.

## Returns
Returns true if all content documents are usable.

## Remarks
This check is slow as it invloves traversal of all content documents.
 It also dumps data about bad families into the journal, as well as the whole content tree into the dump file.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

