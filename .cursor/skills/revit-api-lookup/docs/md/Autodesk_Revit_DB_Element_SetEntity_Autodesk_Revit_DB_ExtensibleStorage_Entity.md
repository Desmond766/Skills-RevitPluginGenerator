---
kind: method
id: M:Autodesk.Revit.DB.Element.SetEntity(Autodesk.Revit.DB.ExtensibleStorage.Entity)
zh: 构件、图元、元素
source: html/e90c01ab-3d2f-2f46-3e88-8297e686dc80.htm
---
# Autodesk.Revit.DB.Element.SetEntity Method

**中文**: 构件、图元、元素

Stores the entity in the element. If an Entity described by the same Schema already
 exists, it is overwritten.

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

