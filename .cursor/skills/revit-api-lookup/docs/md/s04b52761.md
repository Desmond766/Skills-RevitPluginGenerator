---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PipeFittingAndAccessoryPressureDropData.SetDefaultEntity(Autodesk.Revit.DB.ExtensibleStorage.Entity)
source: html/32b58a4f-22ba-fc59-bdc3-8d5316e359eb.htm
---
# Autodesk.Revit.DB.Plumbing.PipeFittingAndAccessoryPressureDropData.SetDefaultEntity Method

Stores the default entity in the data.

## Syntax (C#)
```csharp
public void SetDefaultEntity(
	Entity defaultEntity
)
```

## Parameters
- **defaultEntity** (`Autodesk.Revit.DB.ExtensibleStorage.Entity`) - The Entity to be stored.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Writing of Entities of this Schema is not allowed to the current add-in.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

