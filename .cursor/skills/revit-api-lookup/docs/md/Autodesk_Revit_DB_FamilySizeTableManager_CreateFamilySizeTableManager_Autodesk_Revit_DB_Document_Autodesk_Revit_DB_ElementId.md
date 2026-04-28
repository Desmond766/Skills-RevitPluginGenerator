---
kind: method
id: M:Autodesk.Revit.DB.FamilySizeTableManager.CreateFamilySizeTableManager(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/9b6a6ac2-e778-2df8-b455-0018e1a16b32.htm
---
# Autodesk.Revit.DB.FamilySizeTableManager.CreateFamilySizeTableManager Method

Adds FamilySizeTableManager to a Family.
 A FamilySizeTableManager and FamilySizeTables are only needed when
 importing, exporting, or removing size data previously stored in CSV files.

## Syntax (C#)
```csharp
public static bool CreateFamilySizeTableManager(
	Document document,
	ElementId familyId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Family owned document or project document.
- **familyId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the Family.

## Returns
True if successful, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

