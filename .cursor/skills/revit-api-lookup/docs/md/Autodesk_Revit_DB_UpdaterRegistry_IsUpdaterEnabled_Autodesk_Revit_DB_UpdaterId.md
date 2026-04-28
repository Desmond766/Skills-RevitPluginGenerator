---
kind: method
id: M:Autodesk.Revit.DB.UpdaterRegistry.IsUpdaterEnabled(Autodesk.Revit.DB.UpdaterId)
source: html/52a67f04-adfb-6584-3466-caf8878c5a9d.htm
---
# Autodesk.Revit.DB.UpdaterRegistry.IsUpdaterEnabled Method

Checks if the updater is enabled or not.

## Syntax (C#)
```csharp
public static bool IsUpdaterEnabled(
	UpdaterId id
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.UpdaterId`) - The updater id.

## Returns
Returns true if the updater is enabled, false otherwise.

## Remarks
Even when an updater is enabled it could still be suspended for misbehaving, in which case it would not
 be executed regardless of its enable/disable status.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Updater with this Id is not currently registered in Revit.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

