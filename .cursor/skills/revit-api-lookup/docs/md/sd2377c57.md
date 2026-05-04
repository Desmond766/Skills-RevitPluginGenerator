---
kind: method
id: M:Autodesk.Revit.DB.UpdaterRegistry.IsUpdaterRegistered(Autodesk.Revit.DB.UpdaterId,Autodesk.Revit.DB.Document)
source: html/01ee11a5-bc7d-dc85-892d-66382052badf.htm
---
# Autodesk.Revit.DB.UpdaterRegistry.IsUpdaterRegistered Method

Checks whether updater with the given id is registered in a document.

## Syntax (C#)
```csharp
public static bool IsUpdaterRegistered(
	UpdaterId id,
	Document document
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.UpdaterId`) - Id of the updater being tested.
- **document** (`Autodesk.Revit.DB.Document`) - Document in which this updater is tested whether it's registered or not.

## Returns
Returns True if the updater is registered in the given document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

