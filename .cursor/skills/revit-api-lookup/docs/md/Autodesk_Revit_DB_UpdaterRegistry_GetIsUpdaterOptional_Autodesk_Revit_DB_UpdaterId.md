---
kind: method
id: M:Autodesk.Revit.DB.UpdaterRegistry.GetIsUpdaterOptional(Autodesk.Revit.DB.UpdaterId)
source: html/d5bc0b9a-8623-a155-f077-26f6f2b4d4b3.htm
---
# Autodesk.Revit.DB.UpdaterRegistry.GetIsUpdaterOptional Method

Check if the updater is optional or not.

## Syntax (C#)
```csharp
public static bool GetIsUpdaterOptional(
	UpdaterId id
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.UpdaterId`) - Id of the updater to check

## Returns
Returns True if the updater is optional, False otherwise.

## Remarks
This flag controls whether an updater is going to be required next time a document in which
 it had been used is opened. If a non-optional updater is not found (currently not registered)
 in a document, the end user will be presented with a warning and choices to resolve
 the situation.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Updater with this Id is not currently registered in Revit.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

