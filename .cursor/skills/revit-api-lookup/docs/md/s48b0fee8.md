---
kind: method
id: M:Autodesk.Revit.DB.UpdaterRegistry.SetIsUpdaterOptional(Autodesk.Revit.DB.UpdaterId,System.Boolean)
source: html/c69c2b77-4f3a-4f0a-d87e-530a1b8e5d06.htm
---
# Autodesk.Revit.DB.UpdaterRegistry.SetIsUpdaterOptional Method

Sets a flag indicating whether an updater is optional or not.

## Syntax (C#)
```csharp
public static void SetIsUpdaterOptional(
	UpdaterId id,
	bool isOptional
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.UpdaterId`) - Id of the updater
- **isOptional** (`System.Boolean`) - Use True to make the updater optional, false to make it a mandatory updater.

## Remarks
This flag controls whether an updater is going to be required next time a document in which
 it had been used is opened. If a non-optional updater is not found (currently not registered)
 in a document, the end user will be presented with a warning and choices to resolve
 the situation.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Updater with this Id is not currently registered in Revit.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

