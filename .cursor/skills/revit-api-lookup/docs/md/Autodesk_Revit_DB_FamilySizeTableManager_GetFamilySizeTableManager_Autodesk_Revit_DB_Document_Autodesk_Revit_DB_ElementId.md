---
kind: method
id: M:Autodesk.Revit.DB.FamilySizeTableManager.GetFamilySizeTableManager(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/823ee0d2-cd75-bcd9-8017-df014095b8ea.htm
---
# Autodesk.Revit.DB.FamilySizeTableManager.GetFamilySizeTableManager Method

Gets a FamilySizeTableManager from a Family

## Syntax (C#)
```csharp
public static FamilySizeTableManager GetFamilySizeTableManager(
	Document document,
	ElementId familyId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Family owned document or a project document
- **familyId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the Family.

## Returns
The FamilySizeTableManager of the Family.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

