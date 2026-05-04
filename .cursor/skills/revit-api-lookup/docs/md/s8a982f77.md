---
kind: method
id: M:Autodesk.Revit.UI.Plumbing.PipeFittingAndAccessoryPressureDropUIDataItem.SetEntity(Autodesk.Revit.DB.ExtensibleStorage.Entity)
source: html/265367e2-84e2-bb33-3dce-7ffa6d6b3bcf.htm
---
# Autodesk.Revit.UI.Plumbing.PipeFittingAndAccessoryPressureDropUIDataItem.SetEntity Method

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

