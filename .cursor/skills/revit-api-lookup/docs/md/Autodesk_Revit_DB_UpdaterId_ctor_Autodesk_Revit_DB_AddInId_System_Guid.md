---
kind: method
id: M:Autodesk.Revit.DB.UpdaterId.#ctor(Autodesk.Revit.DB.AddInId,System.Guid)
source: html/bb402a19-a36a-3fce-859f-e43ffa12b385.htm
---
# Autodesk.Revit.DB.UpdaterId.#ctor Method

creates an instance of UpdaterId for given AddInId and a given GUID value

## Syntax (C#)
```csharp
public UpdaterId(
	AddInId addInId,
	Guid val
)
```

## Parameters
- **addInId** (`Autodesk.Revit.DB.AddInId`) - Id of addin that registers an Updater
- **val** (`System.Guid`) - a GUID identifying the Updater within addin

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - addInId is not valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

