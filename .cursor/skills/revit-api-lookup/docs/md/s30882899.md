---
kind: method
id: M:Autodesk.Revit.DB.MassInstanceUtils.RemoveMassLevelDataFromMassInstance(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/92218dd5-d331-c33a-abb2-d6f9956f9204.htm
---
# Autodesk.Revit.DB.MassInstanceUtils.RemoveMassLevelDataFromMassInstance Method

Delete the MassLevelData (Mass Floor) that associates a Level with a mass instance.

## Syntax (C#)
```csharp
public static void RemoveMassLevelDataFromMassInstance(
	Document document,
	ElementId massInstanceId,
	ElementId levelId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Document.
- **massInstanceId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the mass instance.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the Level to disassociate from the mass instance.

## Remarks
Alternatively, you could just delete the MassLevelData.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId massInstanceId is not a mass instance.
 -or-
 The ElementId levelId is not a Level.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

