---
kind: method
id: M:Autodesk.Revit.DB.UpdaterRegistry.DisableUpdater(Autodesk.Revit.DB.UpdaterId)
source: html/23ea00e2-f2ac-8368-ff1b-304ed702a4b5.htm
---
# Autodesk.Revit.DB.UpdaterRegistry.DisableUpdater Method

Disables the updater.

## Syntax (C#)
```csharp
public static void DisableUpdater(
	UpdaterId id
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.UpdaterId`) - The updater id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Updater with this Id is not currently registered in Revit.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

