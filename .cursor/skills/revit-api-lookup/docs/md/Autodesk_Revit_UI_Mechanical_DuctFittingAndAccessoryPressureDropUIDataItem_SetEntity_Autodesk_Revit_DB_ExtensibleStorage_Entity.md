---
kind: method
id: M:Autodesk.Revit.UI.Mechanical.DuctFittingAndAccessoryPressureDropUIDataItem.SetEntity(Autodesk.Revit.DB.ExtensibleStorage.Entity)
source: html/37f83e01-ec61-605f-4d82-8da7e6a1280c.htm
---
# Autodesk.Revit.UI.Mechanical.DuctFittingAndAccessoryPressureDropUIDataItem.SetEntity Method

Stores the entity in the UI data item.

## Syntax (C#)
```csharp
public void SetEntity(
	Entity entity
)
```

## Parameters
- **entity** (`Autodesk.Revit.DB.ExtensibleStorage.Entity`) - The Entity to be stored.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Writing of Entities of this Schema is not allowed to the current add-in.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

