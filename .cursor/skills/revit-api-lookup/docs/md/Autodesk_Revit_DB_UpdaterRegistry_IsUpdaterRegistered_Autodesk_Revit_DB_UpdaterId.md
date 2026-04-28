---
kind: method
id: M:Autodesk.Revit.DB.UpdaterRegistry.IsUpdaterRegistered(Autodesk.Revit.DB.UpdaterId)
source: html/75d78b96-0bd1-2fd5-3618-df48a5c5f1d3.htm
---
# Autodesk.Revit.DB.UpdaterRegistry.IsUpdaterRegistered Method

Checks whether updater with the given id is registered

## Syntax (C#)
```csharp
public static bool IsUpdaterRegistered(
	UpdaterId id
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.UpdaterId`) - Id of the updater being tested.

## Returns
Returns true if the updater is registered.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

