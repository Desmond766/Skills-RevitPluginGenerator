---
kind: method
id: M:Autodesk.Revit.DB.UpdaterRegistry.EnableUpdater(Autodesk.Revit.DB.UpdaterId)
source: html/b75961e9-f8f1-90b0-9c6a-368a2b1c4c03.htm
---
# Autodesk.Revit.DB.UpdaterRegistry.EnableUpdater Method

Enables the updater.

## Syntax (C#)
```csharp
public static void EnableUpdater(
	UpdaterId id
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.UpdaterId`) - The updater id.

## Remarks
Even when an updater is enabled it could still be suspended for misbehaving, in which case it would not
 be executed regardless of its enable/disable status.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Updater with this Id is not currently registered in Revit.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

