---
kind: method
id: M:Autodesk.Revit.DB.LoadedFamilyIntegrityCheck.CheckFamily(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/6e01ffeb-77e1-55e8-b865-a9bda6effe95.htm
---
# Autodesk.Revit.DB.LoadedFamilyIntegrityCheck.CheckFamily Method

Check that the loaded family has its content document.

## Syntax (C#)
```csharp
public static bool CheckFamily(
	Document ADoc,
	ElementId familyId
)
```

## Parameters
- **ADoc** (`Autodesk.Revit.DB.Document`) - The host document.
- **familyId** (`Autodesk.Revit.DB.ElementId`) - The id of the family to check.

## Returns
Returns true if the family has its content document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

