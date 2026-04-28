---
kind: method
id: M:Autodesk.Revit.DB.MassInstanceUtils.AddMassLevelDataToMassInstance(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/fe3b251b-2677-094d-7e72-77fea0f49f24.htm
---
# Autodesk.Revit.DB.MassInstanceUtils.AddMassLevelDataToMassInstance Method

Create a MassLevelData (Mass Floor) to associate a Level with a mass instance.

## Syntax (C#)
```csharp
public static ElementId AddMassLevelDataToMassInstance(
	Document document,
	ElementId massInstanceId,
	ElementId levelId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Document.
- **massInstanceId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the mass instance.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the Level to associate with the mass instance.

## Returns
The ElementId of the MassLevelData that was created, or the existing ElementId if it was already in added.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId massInstanceId is not a mass instance.
 -or-
 The ElementId levelId is not a Level.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

