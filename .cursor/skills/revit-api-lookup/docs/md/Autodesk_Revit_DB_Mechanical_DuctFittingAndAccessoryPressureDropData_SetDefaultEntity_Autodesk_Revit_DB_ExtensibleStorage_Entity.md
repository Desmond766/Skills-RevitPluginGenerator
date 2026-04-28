---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.DuctFittingAndAccessoryPressureDropData.SetDefaultEntity(Autodesk.Revit.DB.ExtensibleStorage.Entity)
source: html/77dc6e7f-392e-51bd-3b0a-27fcda987357.htm
---
# Autodesk.Revit.DB.Mechanical.DuctFittingAndAccessoryPressureDropData.SetDefaultEntity Method

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

